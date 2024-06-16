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
            <div className="position-relative h-100">
                <div className="overflow-auto h-100">
                    <h4 className="fst-italic text-muted mt-4 mb-3 text-center">Appointments history</h4>
                    <table className="table table-striped table-hover border w-75 mx-auto overflow-auto table-responsive">
                        <thead>
                            <tr>
                                <th scope="col"></th>
                                <th scope="col">Start Time</th>
                                <th scope="col">End Time</th>
                                <th scope="col">Status</th>
                            </tr>
                        </thead>
                        <tbody>

                            {appointments.map((appointment, i) => (
                                <tr key={appointment.id}>
                                    <th scope="row">{i + 1}</th>
                                    <td> {new Date(appointment.startingTime).toLocaleString()}</td>
                                    <td> {new Date(appointment.endingTime).toLocaleString()}</td>
                                    <td> {appointment.appointmentStatus === 0 ? <span class="badge bg-warning rounded-pill">Pending</span> : <span class="badge bg-success rounded-pill">Completed</span>}</td>
                                </tr>
                            ))}


                        </tbody>
                    </table>

                </div>
            </div>
            <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
        </div>

    );
};

export default AppointmentHistory;