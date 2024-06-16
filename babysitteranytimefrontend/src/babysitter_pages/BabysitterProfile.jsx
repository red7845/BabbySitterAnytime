﻿import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import { fetchBabysitterByUserId } from '../helpers/apiHelpers.js';
import './BabysitterHomePage.css';

const BabysitterProfile = () => {
    const { babysitterId } = useParams();
    const [babysitter, setBabysitter] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isEditModalOpen, setIsEditModalOpen] = useState(false);
    const [editingCv, setEditingCv] = useState({ title: '', description: '' });
    const [isRatingsModalOpen, setIsRatingsModalOpen] = useState(false);
    const [ratings, setRatings] = useState([]);
    const [isLoading, setIsLoading] = useState(false);


    const fetchBabysitter = async () => {
        setIsLoading(true);
        try {
            const token = localStorage.getItem('authToken');
            const response = await axios.get(`https://localhost:7089/api/Babysitter/GetProfileDetails/${babysitterId}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            setBabysitter(response.data);
        } catch (error) {
            console.error("Failed to fetch babysitter's profile:", error);
        } finally {
            setIsLoading(false);
        }
    };


    useEffect(() => {
        if (babysitterId) {
            fetchBabysitter();
        } else {
            console.error("No babysitter ID found");
            setIsLoading(false);  // Set loading to false to stop showing loader indefinitely
        }
    }, []);

    const handleEditCvClick = async () => {
        try {
            const token = localStorage.getItem('authToken');
            const response = await axios.get(`https://localhost:7089/api/CurriculumVitaes/GetCurriculumVitae/${babysitter.id}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            setEditingCv(response.data);
            setIsEditModalOpen(true);
        } catch (error) {
            console.error("Failed to fetch CV details:", error);
        }
    };

    const handleAddCvClick = () => {
        setIsModalOpen(true);
    };

    const handleModalClose = () => {
        setIsModalOpen(false);
        setIsEditModalOpen(false); // Ensure to close edit modal as well
    };

    const handleModalSubmit = async (cv) => {
        setIsLoading(true);
        try {
            const token = localStorage.getItem('authToken');
            await axios.post('https://localhost:7089/api/CurriculumVitaes/PostCurriculumVitae',
                {
                    ...cv,
                    babysitterId: babysitter.id
                },
                {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                }
            );
            console.log('CV added successfully');
            setTimeout(fetchBabysitter, 1000); 
        } catch (error) {
            console.error('Failed to add CV:', error);
        } finally {
            setIsLoading(false);
        }
    };

    const handleEditCvSubmit = async (updatedCv) => {
        setIsLoading(true);
        try {
            const token = localStorage.getItem('authToken');
            await axios.put(`https://localhost:7089/api/CurriculumVitaes/PutCurriculumVitae/${babysitter.id}`,
                {
                    title: updatedCv.title,
                    description: updatedCv.description,
                    babysitterId: babysitter.id,
                },
                {
                    headers: {
                        'Authorization': `Bearer ${token}`,
                    },
                }
            );
            console.log('CV updated successfully');
            setTimeout(fetchBabysitter, 1000);  
        } catch (error) {
            console.error('Failed to update CV:', error);
        } finally {
            setIsLoading(false);
        }
    };

    const CVModal = ({ isOpen, onClose, onSubmit }) => {
        const [title, setTitle] = useState('');
        const [description, setDescription] = useState('');

        const handleSubmit = () => {
            onSubmit({ title, description });
            onClose(); // Close modal after submission
        };

        if (!isOpen) return null; // Don't render the modal if it's not open

        return (
            <div className="modal" style={{ display: isModalOpen ? 'block' : 'none' }}>
                <div className="modal-content">
                    <span className="close" onClick={onClose}>&times;</span>
                    <h2>Add Curriculum Vitae</h2>
                    <input type="text" placeholder="Title" value={title} onChange={(e) => setTitle(e.target.value)} />
                    <textarea placeholder="Description" value={description} onChange={(e) => setDescription(e.target.value)}></textarea>
                    <button onClick={handleSubmit}>Submit</button>
                </div>
            </div>
        );
    };

    const EditCVModal = ({ isOpen, onClose, cv, onSubmit }) => {
        const [title, setTitle] = useState(cv?.title);
        const [description, setDescription] = useState(cv?.description);

        useEffect(() => {
            if (cv) {
                setTitle(cv.title);
                setDescription(cv.description);
            }
        }, [cv]);

        const handleSubmit = () => {
            onSubmit({
                ...cv,
                title,
                description,
            });
            onClose(); // Close modal after submission
        };

        if (!isOpen) return null;

        return (
            <div className="modal" style={{ display: isEditModalOpen ? 'block' : 'none' }}>
                <div className="modal-content">
                    <span className="close" onClick={onClose}>&times;</span>
                    <h2>Edit Curriculum Vitae</h2>
                    <input type="text" value={title} onChange={(e) => setTitle(e.target.value)} />
                    <textarea value={description} onChange={(e) => setDescription(e.target.value)} />
                    <button onClick={handleSubmit}>Submit Changes</button>
                </div>
            </div>
        );
    };

    const RatingsModal = ({ isOpen, onClose, ratings }) => {
        if (!isOpen) return null;

        return (
            <div className="modal" style={{ display: isOpen ? 'block' : 'none' }}>
                <div className="modal-content">
                    <span className="close" onClick={onClose}>&times;</span>
                    <h2>Ratings</h2>
                    <div>
                        {ratings.map((rating, index) => (
                            <div key={index} className="rating-box">
                                <div>Stars: {"★".repeat(rating.score)}{"☆".repeat(5 - rating.score)}</div>
                                <div>Comment: {rating.comment || "No comment"}</div>
                            </div>
                        ))}
                    </div>
                </div>
            </div>
        );
    };

    const openRatingsModal = async (babysitterId) => {
        try {
            const token = localStorage.getItem('authToken');
            const response = await axios.get(`https://localhost:7089/api/Rating/GetRatingsForBabysitter/${babysitterId}`, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            setRatings(response.data);
            setIsRatingsModalOpen(true);
        } catch (error) {
            console.error("Failed to fetch ratings:", error);
        }
    };

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

    if (!babysitter) {
        return <div>Unable to load babysitter profile. Please try again.</div>;
    }

    return (
        <div className="d-flex flex-column vh-100">
            <nav className="navbar sticky-top bg-pink tex-center d-flex justify-content-center" >
                <div className="text-white p-1 fs-5 fst-italic">Welcome to Babysitter Anytime</div>
            </nav>
            <h1>Babysitter Profile</h1>
            <div className="row">
                <div className="col-md-6">
                    {babysitter.photoUrl ? (
                        <img
                            src={babysitter.photoUrl}
                            alt="Babysitter"
                            className="img-fluid img-thumbnail"
                            style={{ maxWidth: '200px', maxHeight: '200px' }} // Adjusted size
                        />
                    ) : (
                        <p>No image available</p>
                    )}
                    <p><strong>First Name:</strong> {babysitter.firstName}</p>
                    <p><strong>Last Name:</strong> {babysitter.lastName}</p>
                    <p><strong>Phone Number:</strong> {babysitter.phoneNumber}</p>
                    <p><strong>Email:</strong> {babysitter.email}</p>
                    <p><strong>Address:</strong> {babysitter.address}</p>
                    <p><strong>Hourly Rate:</strong> {babysitter.hourlyRate}</p>
                </div>
                <div className="col-md-6">
                    {babysitter.curriculumVitae ? (
                        <div>
                            <h2>Curriculum Vitae</h2>
                            <p><strong>Title:</strong> {babysitter.curriculumVitae.title}</p>
                            <p><strong>Description:</strong> {babysitter.curriculumVitae.description}</p>
                            <button className="btn btn-primary" onClick={handleEditCvClick}>Edit CV</button>
                        </div>
                    ) : (
                        <div>
                            <h2>Curriculum Vitae</h2>
                            <button className="btn btn-primary" onClick={handleAddCvClick}>Add CV</button>
                        </div>
                    )}
                    <p><strong>Score:</strong> {babysitter.score}</p>
                    <button className="btn btn-secondary" onClick={() => openRatingsModal(babysitter.id)}>Show Comments</button>
                </div>
            </div>
            <RatingsModal
                isOpen={isRatingsModalOpen}
                onClose={() => setIsRatingsModalOpen(false)}
                ratings={ratings}
            />
            <CVModal isOpen={isModalOpen} onClose={handleModalClose} onSubmit={handleModalSubmit} />
            <EditCVModal
                isOpen={isEditModalOpen}
                onClose={handleModalClose}
                cv={editingCv}
                onSubmit={handleEditCvSubmit}
            />
            <footer className="mt-auto bg-pink text-light p-2 text-center">
                &#169; Copyright 2024 Redina. All rights reserved
            </footer>
        </div>
    );
};

export default BabysitterProfile;