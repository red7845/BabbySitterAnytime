import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import './CustomerHomePage.css';
import Select from 'react-select';

const CustomerHomePage = () => {
    const navigate = useNavigate();
    const [babysitters, setBabysitters] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedBabysitterId, setSelectedBabysitterId] = useState(null);
    const [isRatingModalOpen, setIsRatingModalOpen] = useState(false);
    const [ratingScore, setRatingScore] = useState(0);
    const [isCvModalOpen, setIsCvModalOpen] = useState(false);
    const [currentCv, setCurrentCv] = useState(null);
    const [ratingComment, setRatingComment] = useState('');
    const [areas, setAreas] = useState([]);
    const [selectedArea, setSelectedArea] = useState(null);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState("");
    const [noBabysittersMessage, setNoBabysittersMessage] = useState('');
    const [customer, setCustomer] = useState('');

    const [appointmentDetails, setAppointmentDetails] = useState({
        startDate: '',
        endDate: '',
        startTime: '',
        endTime: '',
    });

    useEffect(() => {
        const fetchAreas = async () => {
            try {
                const response = await axios.get('https://localhost:7089/api/Area/GetAllAreas');
                setAreas(response.data.map(area => ({ value: area.id, label: area.name })));
            } catch (error) {
                console.error('Failed to fetch areas:', error);
            }
        };

        fetchAreas();
    }, []);

    const openModal = (babysitterId) => {
        setSelectedBabysitterId(babysitterId);
        setIsModalOpen(true);
    };

    function convertTo24Hour(timeString) {
        const [time, modifier] = timeString.split(' ');
        let [hours, minutes] = time.split(':');

        if (modifier === 'μμ' && hours !== '12') {
            hours = parseInt(hours, 10) + 12;
        } else if (modifier === 'πμ' && hours === '12') {
            hours = '00';
        }

        return `${hours.padStart(2, '0')}:${minutes}`;
    }

    const openRatingModal = (babysitterId) => {
        setSelectedBabysitterId(babysitterId);
        setIsRatingModalOpen(true);
        setRatingScore(0); // Reset score whenever opening the modal
    };

    const closeRatingModal = (babysitterId) => {
        setIsRatingModalOpen(false);
    };

    const customerName = localStorage.getItem('customerName')

    const closeModal = () => {
        setIsModalOpen(false);
    };

    const openCvModal = async (babysitterId) => {
        try {
            const token = localStorage.getItem('authToken');
            const cvResponse = await axios.get(`https://localhost:7089/api/CurriculumVitaes/GetCurriculumVitae/${babysitterId}`, {
                headers: { 'Authorization': `Bearer ${token}` }
            });
            setCurrentCv(cvResponse.data);
            setIsCvModalOpen(true);
        } catch (error) {
            console.error("Failed to fetch CV:", error);
        }
    };

    const handleAreaChange = (selectedOption) => {
        setSelectedArea(selectedOption);
    };


    const bookAppointment = async () => {
        try {
            const token = localStorage.getItem('authToken');
            const userId = localStorage.getItem('userId');

            const customer = await axios.get(`https://localhost:7089/api/Client/GetCustomerByUserId/${userId}`, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`,
                }
            });

            const customerId = customer.data.id


            const startDate = appointmentDetails.startDate;
            const startTime = appointmentDetails.startTime;
            const endDate = appointmentDetails.endDate;
            const endTime = appointmentDetails.endTime;

            const startingTime = new Date(`${startDate}T${startTime}:00`);
            const endingTime = new Date(`${endDate}T${endTime}:00`);

            console.log('Starting Time (ISO):', startingTime.toISOString());
            console.log('Ending Time (ISO):', endingTime.toISOString());

            const requestBody = {
                babysitterId: selectedBabysitterId,
                clientId: customerId,
                startingTime: startingTime.toISOString(),
                endingTime: endingTime.toISOString(),
                area: "The area you want to specify",
                status: 1
            };

            const response = await axios.post('https://localhost:7089/api/Appointment/CreateAppointment', requestBody, {
                headers: {
                    'Authorization': `Bearer ${token}`,
                },
            });

            closeModal();

        } catch (error) {
            console.error('Failed to book appointment:', error);
        }
    };

    const RatingStars = ({ onRate }) => {
        return (
            <div>
                {[...Array(5)].map((star, index) => {
                    return (
                        <button
                            key={index}
                            style={{ color: index < ratingScore ? '#ffc107' : '#e4e5e9' }}
                            onClick={() => onRate(index + 1)}
                        >
                            ★
                        </button>
                    );
                })}
            </div>
        );
    };

    const submitRating = async () => {
        try {
            const token = localStorage.getItem('authToken');
            await axios.post('https://localhost:7089/api/Rating/AddRating', {
                score: ratingScore,
                comment: ratingComment,
                babysitterId: selectedBabysitterId
            }, {
                headers: {
                    'Authorization': `Bearer ${token}`,
                },
            });
            setIsRatingModalOpen(false); // Close the modal after submission
        } catch (error) {
            console.error('Failed to submit rating:', error);
        }
    };

    const logout = async () => {
        try {
            const token = localStorage.getItem('authToken');
            await axios.post('https://localhost:7089/api/auth/logout', {}, {
                headers: {
                    'Authorization': `Bearer ${token}`,
                }
            });
            localStorage.removeItem('authToken');
            localStorage.removeItem('userId');
            window.location.href = '/login';
        } catch (error) {
            console.error('Logout failed:', error);
        }
    };

    const fetchBabysittersByArea = async () => {
        if (selectedArea) {
            setIsLoading(true);
            setBabysitters([]); // Clear previous babysitters immediately when search starts
            setNoBabysittersMessage(''); // Clear previous messages
            try {
                const token = localStorage.getItem('authToken');
                const response = await axios.get(`https://localhost:7089/api/Babysitter/GetBabysittersBySupportingArea/${selectedArea.value}`, {
                    headers: {
                        'Authorization': `Bearer ${token}`,
                    },
                });
                if (response.data.length === 0) {
                    setNoBabysittersMessage('No babysitters available in this area.');
                }
                setBabysitters(response.data);
            } catch (error) {
                setError('Error finding babysitters')
                if (error.response && error.response.status === 404) {
                    setNoBabysittersMessage('No babysitters available in this area.');
                } else {
                    console.error('Failed to fetch babysitters by area:', error);
                }
            } finally {
                setIsLoading(false);
            }
        }
    };

    return (
        <div>

            <nav className="navbar sticky-top bg-pink tex-center d-flex justify-content-center" >
                <div className="text-white p-1 fs-5 fst-italic"> Babysitter Anytime</div>
            </nav>


            <div className="vh-100 container pt-4">

                <div className="row">
                    <div className=" fst-italic fs-3 mb-4 ps-0 col-12 text-muted " >Welcome {customerName || 'Customer'}!</div>
                    <div className="col-4  pb-3  height-fit-content border  rounded p-4">

                        {/*<div className="top-right-buttons">*/}
                        {/*    <button onClick={() => navigate('/customer-edit-profile')}>Edit Profile</button>*/}
                        {/*    <button onClick={() => navigate('/customer-appointment-history')}>Appointment History</button>*/}
                        {/*    <button onClick={logout}>Logout</button>*/}
                        {/*</div>*/}

                        <div className="row g-3">
                            <div className="col-12">
                                <label className="mb-2">Select your area</label>
                                <Select
                                    options={areas}
                                    onChange={handleAreaChange}
                                    className="area-dropdown"
                                    placeholder="Select.."
                                />
                            </div>
                            <div className="col-12 pb-3">
                                <button onClick={fetchBabysittersByArea} className="btn btn-primary btn-small w-100" disabled={!selectedArea}>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-search" viewBox="0 0 16 16">
                                        <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001q.044.06.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1 1 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0" />
                                    </svg>
                                    <span className="ms-2">Search</span></button>
                            </div>
                        </div>
                    </div>


                    <div className="babysitters-list col-8 overflow-auto h-391px">
                        {
                            !selectedArea
                                ? <div className="alert alert-info d-inline-flex align-items-center p-3" role="alert">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="22" height="22" fill="currentColor" className="bi bi-info-circle" viewBox="0 0 16 16">
                                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                        <path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0" />
                                    </svg>
                                    <span className="ms-2  small">
                                        In order to search for a baby sitter, select first your desired area from the menu on the left
                                    </span>
                                </div>
                                : selectedArea && !isLoading && !error && babysitters.length === 0 ?
                                    <div className="alert alert-info d-inline-flex align-items-center p-3" role="alert">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="22" height="22" fill="currentColor" className="bi bi-info-circle" viewBox="0 0 16 16">
                                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                                            <path d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0" />
                                        </svg>
                                        <span className="ms-2  small">
                                            Click the search button to start searching for baby sitters..
                                        </span>
                                    </div>

                                    : isLoading
                                        ? <div className="alert alert-info p-2 d-flex align-items-center" role="alert">
                                            <div className="spinner" role="status"> </div>
                                            <span className="ms-2"> Loading baby sitters...</span>
                                        </div>
                                        : error
                                            ? <div className="alert alert-danger p-3" role="alert"> Error fetching baby sitters. Please try again</div>
                                            : noBabysittersMessage
                                                ? <div className="alert alert-info p-3" role="alert">No babysitters found</div>
                                                :
                                                babysitters.map(babysitter => (
                                                    <div key={babysitter.id} className="border rounded p-3" >
                                                        <div className="row">
                                                            <div className="col-3">
                                                                {babysitter.photoUrl ? (
                                                                    <img src={babysitter.photoUrl} alt={`${babysitter.firstName} ${babysitter.lastName}`} style={{ width: '200px', height: '150px' }} />
                                                                ) : (
                                                                    <div style={{ width: '100px', height: '100px', background: '#ccc' }}>No Image</div>
                                                                )}
                                                            </div>
                                                            <div className="col-4">
                                                                <div><strong>Name:</strong> {babysitter.firstName} {babysitter.lastName}</div>
                                                                <div><strong>Email:</strong> {babysitter.email}</div>
                                                                <div><strong>Phone:</strong> {babysitter.phoneNumber}</div>
                                                                <div><strong>Address:</strong> {babysitter.address}</div>
                                                                <div><strong>Hourly Rate:</strong> {babysitter.hourlyRate}</div>
                                                                <div><strong>Score:</strong> {babysitter.score}</div>
                                                            </div>
                                                            <div className="col-5">
                                                                <button onClick={() => openCvModal(babysitter.id)}>View CV</button>
                                                                <button onClick={() => openModal(babysitter.id)}>Book Appointment</button>
                                                                <button onClick={() => openRatingModal(babysitter.id)}>Rate</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                ))
                        }

                    </div>
                    {isModalOpen && (
                        <div className="modal" style={{ display: isModalOpen ? 'block' : 'none' }}>
                            <div className="modal-content p-3 pt-2">
                                <div className="d-flex justify-content-between align-items-center">
                                    <h4>Book Appointment</h4>
                                    <button className="close fs-3 px-3 p-0  mb-1" onClick={closeModal}>&times;</button>
                                </div>
                                <hr className="mt-2 mb-4"></hr>
                                <form>
                                    <div className="row">
                                        <div className="col-6">
                                            <label htmlFor="start-date">Start Date:</label>
                                            <input
                                                type="date"
                                                id="start-date"
                                                required
                                                className="border w-100 p-1 mt-1"
                                                value={appointmentDetails.startDate}
                                                onChange={(e) => setAppointmentDetails(prev => ({ ...prev, startDate: e.target.value }))}
                                            />
                                        </div>
                                        <div className="col-6">
                                            <label htmlFor="end-date">End Date:</label>
                                            <input
                                                type="date"
                                                id="end-date"
                                                className="border w-100 p-1 mt-1"
                                                required
                                                value={appointmentDetails.endDate}
                                                onChange={(e) => setAppointmentDetails(prev => ({ ...prev, endDate: e.target.value }))}
                                            />
                                        </div>
                                    </div>

                                    <div className="row mt-3">
                                        <div className="col-6">
                                            <label htmlFor="start-time">Start Time:</label>
                                            <input
                                                type="time"
                                                className="border w-100 p-1 mt-1"
                                                id="start-time"
                                                required
                                                value={appointmentDetails.startTime.replace(' πμ', '').replace(' μμ', '')}
                                                onChange={(e) => setAppointmentDetails(prev => ({ ...prev, startTime: e.target.value }))}
                                            />
                                        </div>

                                        <div className="col-6">
                                            <label htmlFor="end-time">End Time:</label>
                                            <input
                                                type="time"
                                                required
                                                className="border w-100 p-1 mt-1"
                                                id="end-time"
                                                value={appointmentDetails.endTime.replace(' πμ', '').replace(' μμ', '')}
                                                onChange={(e) => setAppointmentDetails(prev => ({ ...prev, endTime: e.target.value }))}
                                            />
                                        </div>
                                    </div>
                                    <button type="button" className="btn btn-primary btn-sm mt-3" onClick={bookAppointment}>Confirm Appointment</button>
                                </form>
                            </div>
                        </div>
                    )}

                    {isRatingModalOpen && (
                        <div className="modal" style={{ display: isRatingModalOpen ? 'block' : 'none' }}>
                            <div className="modal-content">
                                <span className="close" onClick={() => setIsRatingModalOpen(false)}>&times;</span>
                                <h2>Rate Babysitter</h2>
                                <RatingStars onRate={setRatingScore} />
                                <textarea
                                    placeholder="Leave a comment (optional)"
                                    value={ratingComment}
                                    onChange={(e) => setRatingComment(e.target.value)}
                                ></textarea>
                                <button onClick={submitRating}>Submit Rating</button>
                            </div>
                        </div>
                    )}

                    {isCvModalOpen && (
                        <div className="modal" style={{ display: isCvModalOpen ? 'block' : 'none' }}>
                            <div className="modal-content">
                                <span className="close" onClick={() => setIsCvModalOpen(false)}>&times;</span>
                                <h2>Curriculum Vitae</h2>
                                <p><strong>Title:</strong> {currentCv?.title}</p>
                                <p><strong>Description:</strong> {currentCv?.description}</p>
                                {/* Add more CV details here if necessary */}
                            </div>
                        </div>
                    )}
                    {/* Customer-specific content */}

                </div>
            </div>
            <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
        </div>
    );
};

export default CustomerHomePage;