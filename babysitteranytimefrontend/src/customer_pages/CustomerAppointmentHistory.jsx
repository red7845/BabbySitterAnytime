import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './AppointmentHistory.css'; // Import your CSS for styling
import { fetchCustomerByUserId } from '../helpers/apiHelpers.js';
import './CustomerHomePage.css'; // Import the CSS file you'll create for styling

const AppointmentHistory = () => {
    const [appointments, setAppointments] = useState([]);
    const [customer, setCustomer] = useState(null);
    const [cancelingAppointmentId, setCancelingAppointmentId] = useState(null);
    const [isCancelConfirmationOpen, setIsCancelConfirmationOpen] = useState(false);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        const fetchAppointments = async () => {
            setLoading(true); // Start loading
            try {
                const token = localStorage.getItem('authToken');
                const userId = localStorage.getItem('userId');
                const customerData = await fetchCustomerByUserId(userId);

                const response = await axios.get(`https://localhost:7089/api/Appointment/GetAppointmentsForCustomer/${customerData.id}`, {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                });
                setAppointments(response.data);
            } catch (error) {
                console.error("Failed to fetch appointments:", error);
            } finally {
                setLoading(false); // End loading
            }
        };

        fetchAppointments();
    }, []);

    const handleCancelConfirmation = async (appointmentId) => {
        setIsCancelConfirmationOpen(true);
        setCancelingAppointmentId(appointmentId);
    };

    const handleCancelAppointment = async () => {
        try {
            const token = localStorage.getItem('authToken');
            const appointment = appointments.find(appointment => appointment.id === cancelingAppointmentId);
            const requestBody = {
                startingTime: appointment.startingTime,
                endingTime: appointment.endingTime,
                appointmentStatus: 2
            };
            await axios.put(`https://localhost:7089/api/Appointment/EditAppointment/${cancelingAppointmentId}`, requestBody, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            // Update appointments list after cancellation
            const updatedAppointments = appointments.map(appointment =>
                appointment.id === cancelingAppointmentId ? { ...appointment, appointmentStatus: 2 } : appointment
            );
            setAppointments(updatedAppointments);
            setIsCancelConfirmationOpen(false); // Close the confirmation modal
        } catch (error) {
            console.error("Failed to cancel appointment:", error);
        }
    };

    const handleCloseCancelConfirmation = () => {
        setIsCancelConfirmationOpen(false);
        setCancelingAppointmentId(null);
    };


    return (
        <div className="vh-100">
            <nav className="navbar sticky-top bg-pink tex-center d-flex justify-content-center" >
                <div className="text-white p-1 fs-5 fst-italic">Welcome to Babysitter Anytime</div>
            </nav>
            <div className="h-100 container-fluid">
            {loading ? (
                <div className="loader"></div>
            ) : (
                appointments.length > 0 ? (
                    appointments.map(appointment => (
                        <div key={appointment.id} className="appointment-box">
                            <div><strong>Area:</strong> {appointment.area}</div>
                            <div><strong>Start Time:</strong> {new Date(appointment.startingTime).toLocaleString()}</div>
                            <div><strong>End Time:</strong> {new Date(appointment.endingTime).toLocaleString()}</div>
                            <div><strong>Status:</strong>
                                {appointment.appointmentStatus === 0 ? 'Accepted' :
                                    appointment.appointmentStatus === 1 ? 'Pending' :
                                        appointment.appointmentStatus === 2 ? 'Cancelled' : 'Unknown'}
                            </div>
                            {appointment.appointmentStatus === 0 && (
                                <button onClick={() => handleCancelConfirmation(appointment.id)}>Cancel Appointment</button>
                            )}
                        </div>
                    ))
                        ) : (
                     <div className="text-center mt-3">
                        <div className="alert alert-info text-center margin-auto">There are no appointments available</div>
                    </div>
                )
            )}
            {isCancelConfirmationOpen && (
                <div className="modal" style={{ display: 'block' }}>
                    <div className="modal-content">
                        <h2>Cancel Appointment</h2>
                        <p>Are you sure you want to cancel this appointment?</p>
                        <div>
                            <button onClick={handleCancelAppointment}>Yes</button>
                            <button onClick={handleCloseCancelConfirmation}>No</button>
                        </div>
                    </div>
                </div>
                )}
            </div>
                <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
        
        </div>
    );
};

export default AppointmentHistory;