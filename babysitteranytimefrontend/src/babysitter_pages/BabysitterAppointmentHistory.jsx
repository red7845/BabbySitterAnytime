import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './AppointmentHistory.css'; // Import your CSS for styling
import { fetchBabysitterByUserId } from '../helpers/apiHelpers.js';

const AppointmentHistory = () => {
    const [appointments, setAppointments] = useState([]);
    const [babysitter, setBabysitter] = useState(null);
    const [isLoading, setIsLoading] = useState(true); 

    useEffect(() => {
        const fetchAppointments = async () => {
            try {
                setIsLoading(true);
                const token = localStorage.getItem('authToken');
                const userId = localStorage.getItem('userId');
                const babysitterData = await fetchBabysitterByUserId(userId);

                const response = await axios.get(`https://localhost:7089/api/Appointment/GetAppointmentsForBabysitter/${babysitterData.id}`, {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                });
                setAppointments(response.data);
            } catch (error) {
                console.error("Failed to fetch appointments:", error);
            } finally {
                setIsLoading(false);  // End loading
            }
        };

        fetchAppointments();
    }, []);

    if (isLoading) {
        return (

            <div className="vh-100">
                <nav className="navbar sticky-top bg-pink tex-center d-flex justify-content-center" >
                    <div className="text-white p-1 fs-5 fst-italic">Welcome to Babysitter Anytime</div>
                </nav>
                <div className="d-flex justify-content-center mt-5 h-100">
                    <div className="spinner" role="status"> </div>
                </div>
                <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
            </div>
        )
    }

    else if (appointments.length === 0) {
        if (isLoading) {
            return (

                <div className="vh-100">
                    <nav className="navbar sticky-top bg-pink tex-center d-flex justify-content-center" >
                        <div className="text-white p-1 fs-5 fst-italic">Welcome to Babysitter Anytime</div>
                    </nav>
                    <div className=" mt-5 h-100">
                        <div className="alert alert-info w-100 col-12">No appointments found </div>
                    </div>
                    <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
                </div>
            )
        }

    }

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
                                    <th scope="col">#</th>
                                    <th scope="col">Area</th>
                                    <th scope="col">Start Time</th>
                                    <th scope="col">End Time</th>
                                    <th scope="col">Status</th>
                                </tr>
                            </thead>
                            <tbody>

                                {appointments.map((appointment, i) => (
                                    <tr key={appointment.id}>
                                        <th scope="row">{i + 1}</th>
                                        <td> {appointment.area}</td>
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