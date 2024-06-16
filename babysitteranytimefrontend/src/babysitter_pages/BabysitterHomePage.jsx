import React, { useState, useEffect } from 'react';
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import axios from 'axios';
import './BabysitterHomePage.css';
import { useNavigate } from 'react-router-dom';
import { fetchBabysitterByUserId } from '../helpers/apiHelpers.js';

const BabysitterHomePage = () => {
    const navigate = useNavigate();
    const localizer = momentLocalizer(moment);

    const [events, setEvents] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedAppointment, setSelectedAppointment] = useState(null);
    const [status, setStatus] = useState('');
    const [statusOptions] = useState([
        { value: 0, label: 'Accepted' },
        { value: 1, label: 'Pending' },
        { value: 2, label: 'Deleted' }
    ]);
    const [babysitter, setBabysitter] = useState(null);
    const [isLoading, setIsLoading] = useState(false);
    const statusText = {
        0: 'Accepted',
        1: 'Pending',
        2: 'Deleted'
    };

    const editAppointment = async () => {
        setIsLoading(true);
        try {
            const token = localStorage.getItem('authToken');

            const response = await axios.put(`https://localhost:7089/api/Appointment/EditAppointment/${selectedAppointment.id}`, {
                startingTime: new Date(selectedAppointment.start).toISOString(),
                endingTime: new Date(selectedAppointment.end).toISOString(),
                appointmentStatus: parseInt(status, 10)
            }, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });

            setIsModalOpen(false);
            fetchAppointments();
        } catch (error) {
            console.error('Error editing the appointment:', error);
        } finally {
            setIsLoading(false); // End loading
            setIsModalOpen(false); // Close modal after action
        }
    };

    const fetchAppointments = async () => {
        setIsLoading(true); // Start loading
        const token = localStorage.getItem('authToken');
        const userId = localStorage.getItem('userId');

        try {
            const babysitterData = await fetchBabysitterByUserId(userId);
            setBabysitter(babysitterData);
            const response = await axios.get(`https://localhost:7089/api/Appointment/GetAppointmentsForBabysitter/${babysitterData.id}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            const appointments = response.data.map(appointment => ({
                id: appointment.id,
                title: `Appointment: ${moment(appointment.startingTime).format('HH:mm')} - ${moment(appointment.endingTime).format('HH:mm')}`,
                start: new Date(appointment.startingTime),
                end: new Date(appointment.endingTime),
                appointmentStatus: appointment.appointmentStatus
            }));
            setEvents(appointments);
        } catch (error) {
            console.error('Failed to fetch appointments:', error);
        } finally {
            setIsLoading(false); // End loading
        }
    };

    const handleEventClick = (appointment) => {
        setSelectedAppointment(appointment);
        setStatus(appointment.appointmentStatus);
        setIsModalOpen(true);
    };

    const handleStatusChange = (e) => {
        setStatus(e.target.value);
    };

    const AppointmentModal = ({ appointment, onClose }) => {
        if (!appointment) return null; // Don't render the modal if there's no appointment selected
        const appointmentStatusText = statusText[appointment.appointmentStatus] || 'Unknown';
        return (
            <div className="modal" style={{ display: isModalOpen ? 'block' : 'none' }}>
                <div className="modal-content">
                    <span className="close" onClick={onClose}>&times;</span>
                    <h2>Appointment Details</h2>
                    <p><strong>Time:</strong> {moment(appointment.start).format('MMMM Do YYYY, h:mm a')} - {moment(appointment.end).format('h:mm a')}</p>
                    <p><strong>Status:</strong> {appointmentStatusText}</p>
                    <select value={status} onChange={handleStatusChange}>
                        {statusOptions.map(option => (
                            <option key={option.value} value={option.value}>{option.label}</option>
                        ))}
                    </select>
                    <button onClick={editAppointment}>Edit Appointment</button>
                </div>
            </div>
        );
    };

    useEffect(() => {
        fetchAppointments();
    }, []);

    const handleProfileClick = () => {
        if (babysitter && babysitter.id) {
            navigate(`/babysitter-profile/${babysitter.id}`);
        } else {
            console.error('Babysitter ID not found');
        }
    };

    const logout = async () => {
        const token = localStorage.getItem('authToken');
        await axios.post('https://localhost:7089/api/auth/logout', {}, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        localStorage.removeItem('authToken');
        localStorage.removeItem('userId');
        navigate('/login');
    };

    const getColor = (status) => {
        switch (status) {
            case 0: return 'green';
            case 1: return 'yellow';
            case 2: return 'red';
            default: return 'blue';
        }
    };

    const eventStyleGetter = (event) => {
        let backgroundColor = getColor(event.appointmentStatus);
        return {
            style: {
                backgroundColor: backgroundColor,
                borderRadius: '0px',
                opacity: 0.8,
                color: 'black',
                border: '0px',
                display: 'block'
            }
        };
    };

    return (
        <div className="parent-container">
            {isLoading ? (
                <div className="vh-100">
                    <nav className="navbar sticky-top bg-pink tex-center d-flex justify-content-center" >
                        <div className="text-white p-1 fs-5 fst-italic">Welcome to Babysitter Anytime</div>
                    </nav>
                    <div className="d-flex justify-content-center mt-5">
                        <div className="spinner" role="status"> </div>
                    </div>
                </div>
            ) : (
                <>
                        <div className="header">
                            <nav className="navbar sticky-top bg-pink tex-center d-flex justify-content-center" >
                                <div className="text-white p-1 fs-5 fst-italic">Welcome to Babysitter Anytime</div>
                            </nav>
                        {/* Uncomment and use the below buttons if needed */}
                        {/*<div className="top-right-buttons">
                        <button onClick={handleProfileClick}>Profile</button>
                        <button onClick={() => navigate('/babysitter-appointment-history')}>Appointment History</button>
                        <button onClick={() => navigate('/babysitter-edit-profile')}>Edit Profile</button>
                        <button onClick={logout}>Logout</button>
                    </div>*/}
                    </div>
                    <div className="calendar-container p-3">
                        <Calendar
                            localizer={momentLocalizer(moment)}
                            events={events}
                            startAccessor="start"
                            endAccessor="end"
                            eventPropGetter={eventStyleGetter}
                            onSelectEvent={handleEventClick}
                                style={{ height: '100%', width: '100%' }}
                        /></div>
                    {isModalOpen && (
                        <AppointmentModal
                            appointment={selectedAppointment}
                            onClose={() => setIsModalOpen(false)}
                        />
                    )}
                </>
            )}
            <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
        </div>
    );
};

export default BabysitterHomePage;