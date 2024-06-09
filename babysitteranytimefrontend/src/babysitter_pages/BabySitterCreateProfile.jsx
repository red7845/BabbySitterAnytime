import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import addImageIconUrl from '../assets/camera-add-svgrepo-com.svg'; // Import the SVG file
import './BabysitterHomePage.css'; // Make sure the path is correct
import Select from 'react-select';

const BabySitterCreateProfile = () => {
    const navigate = useNavigate(); // Hook to get the navigate function
    const [areas, setAreas] = useState([]); // To store area options from the API
    const [selectedAreas, setSelectedAreas] = useState([]);
    const [profileData, setProfileData] = useState({
        firstName: '',
        lastName: '',
        address: '',
        phoneNumber: '',
        email: '',
        yearsOfExperience: '',
        hourlyRate: '', 
        photoUrl: '', 

    });

    useEffect(() => {
        const fetchAreas = async () => {
            try {
                const response = await axios.get('https://localhost:7089/api/Area/GetAllAreas');
                console.log("API Response:", response.data); // Add this line to check the actual structure
                setAreas(response.data);
            } catch (error) {
                console.error('Failed to fetch areas:', error);
            }
        };

        fetchAreas();
    }, []);

    const areaOptions = areas.map(area => ({ label: area.name, value: area.id }));

    const handleReactSelectChange = (selectedOptions) => {
        const values = selectedOptions.map(option => option.value);
        setSelectedAreas(values);
    };

    const handleChange = (e) => {
        setProfileData({
            ...profileData,
            [e.target.name]: e.target.value
        });
    };

    const handleImageUpload = (e) => {
        const file = e.target.files[0]; // Get the file
        if (file) {
            const reader = new FileReader();
            reader.onloadend = () => {
                // This will be called once the reader has completed reading the file
                setProfileData({
                    ...profileData,
                    photoUrl: reader.result // This assumes you want to store the image as a base64 encoded string
                });
            };
            reader.readAsDataURL(file); // Read the file as a Data URL (base64 string)
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const token = localStorage.getItem('authToken');
        const userId = localStorage.getItem('userId');

        const profileDataWithAreas = {
            ...profileData,
            userId,
            areaIds: selectedAreas  // Ensure this is an array of strings (area IDs)
        };

        try {
            const url = 'https://localhost:7089/api/Babysitter/CreatePofile';
            console.log(profileDataWithAreas)
            console.log(token)
            console.log(userId)

            const response = await axios.post(url, profileDataWithAreas, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            });
            console.log(response.data);
            navigate('/babysitter-home');
        } catch (error) {
            console.error('There was an error creating the babysitter profile:', error);
        }
    };

    return (
        <div className="container mt-5">
            <h2>Create BabySitter Profile</h2>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="firstName">First Name</label>
                    <input
                        type="text"
                        id="firstName"
                        name="firstName"
                        value={profileData.firstName}
                        onChange={handleChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="lastName">Last Name</label>
                    <input
                        type="text"
                        id="lastName"
                        name="lastName"
                        value={profileData.lastName}
                        onChange={handleChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="address">Address</label>
                    <input
                        type="text"
                        id="address"
                        name="address"
                        value={profileData.address}
                        onChange={handleChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="phoneNumber">Phone Number</label>
                    <input
                        type="text"
                        id="phoneNumber"
                        name="phoneNumber"
                        value={profileData.phoneNumber}
                        onChange={handleChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="email">Email</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        value={profileData.email}
                        onChange={handleChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="hourlyRate">Hourly Rate</label>
                    <input
                        type="numeric"
                        id="hourlyRate"
                        name="hourlyRate"
                        value={profileData.hourlyRate}
                        onChange={handleChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="photo">Photo</label>
                    <input
                        type="file"
                        id="photo"
                        name="photo"
                        accept="image/*" // This restricts the file picker to image files
                        onChange={handleImageUpload}
                        className="form-control"
                    />
                </div>
                <Select
                    isMulti
                    options={areaOptions}
                    className="basic-multi-select"
                    classNamePrefix="select"
                    onChange={handleReactSelectChange}
                    value={areaOptions.filter(option => selectedAreas.includes(option.value))}
                />
                <button type="submit" className="btn btn-primary mt-3">Create Profile</button>
            </form>
        </div>
    );
};

export default BabySitterCreateProfile;
