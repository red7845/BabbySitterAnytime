import React, { useState, useEffect } from 'react'; 
import axios from 'axios';
import { fetchBabysitterByUserId } from '../helpers/apiHelpers.js';
import { useNavigate } from 'react-router-dom';

const EditBabysitterProfile = () => {
    const navigate = useNavigate();
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [email, setEmail] = useState('');
    const [address, setAddress] = useState('');
    const [babysitterId, setBabysitterId] = useState('');
    const [userId, setUserId] = useState(localStorage.getItem('userId'));
    const [photoUrl, setPhotoUrl] = useState('');
    const [hourlyRate, setHourlyRate] = useState(0);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        const userId = localStorage.getItem('userId');
        if (userId) {
            fetchBabysitterByUserId(userId).then(babysitterData => {
                // Update the state with the fetched data
                setBabysitterId(babysitterData.id)
                setFirstName(babysitterData.firstName);
                setLastName(babysitterData.lastName);
                setPhoneNumber(babysitterData.phoneNumber);
                setEmail(babysitterData.email);
                setAddress(babysitterData.address);
                setPhotoUrl(babysitterData.photoUrl);
                setHourlyRate(babysitterData.hourlyRate);
                setIsLoading(false);
            }).catch(error => {
                console.error("Failed to fetch babysitter's profile:", error);
                setIsLoading(false); 
            });
        }
    }, []);


    const handleImageUpload = (e) => {
        const file = e.target.files[0]; // Get the file
        if (file) {
            const reader = new FileReader();
            reader.onloadend = () => {
                // Set photoUrl to the base64 encoded string
                setPhotoUrl(reader.result);
            };
            reader.readAsDataURL(file); // Read the file as a Data URL (base64 string)
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        const token = localStorage.getItem('authToken');
        const url = `https://localhost:7089/api/Babysitter/EditProfile/${babysitterId}`;

        try {
            const response = await axios.put(url, {
                firstName,
                lastName,
                phoneNumber,
                email,
                address,
                userId, 
                photoUrl,
                hourlyRate
            }, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            navigate('/babysitter-home');
            // Handle the response, e.g., show a success message or redirect
        } catch (error) {
            console.error('Error updating the profile:', error);
            // Handle the error, e.g., show an error message
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


    return (
        <div className="vh-100">
            <nav className="navbar sticky-top bg-pink tex-center d-flex justify-content-center" >
                <div className="text-white p-1 fs-5 fst-italic">Welcome to Babysitter Anytime</div>
            </nav>

            <div className="container h-100 ">
                <form onSubmit={handleSubmit} className="card card-body w-50 mx-auto mt-4">
                    <h4 className="text-center">Edit Profile</h4>
                <div className="row">
                    <div className="form-group my-2 col-6">
                        <label htmlFor="firstName" className="text-muted pb-1">First Name</label>
                        <input type="text" className="form-control" id="firstName" value={firstName} onChange={e => setFirstName(e.target.value)} placeholder="First Name" required/>
                    </div>
                    <div className="form-group my-2 col-6">
                        <label htmlFor="lastName" className="text-muted pb-1">Last Name</label>
                        <input type="text" className="form-control" id="lastName" value={lastName} onChange={e => setLastName(e.target.value)} placeholder="Last Name" required />
                    </div>
                    </div>
                    <div className="row">
                    <div className="form-group my-2 col-6">
                        <label htmlFor="phone" className="text-muted pb-1">Phone Number</label>
                        <input type="tel" className="form-control" id="phone" value={phoneNumber} onChange={e => setPhoneNumber(e.target.value)} placeholder="Phone Number" required />
                    </div>
                    <div className="form-group my-2 col-6">
                        <label htmlFor="email" className="text-muted pb-1">Email</label>
                        <input type="email" className="form-control" id="email" value={email} onChange={e => setEmail(e.target.value)} placeholder="Email" required />
                        </div>
                    </div>
                    <div className="row">
                    <div className="form-group my-2 col-6">
                        <label htmlFor="username" className="text-muted pb-1">Address</label>
                        <input type="text" className="form-control" id="address" value={address} onChange={e => setAddress(e.target.value)} placeholder="Address" required />
                    </div>
                     <div className="form-group my-2 col-6">
                        <label htmlFor="hourlyRate" className="text-muted pb-1">Hourly Rate</label>
                        <input type="numeric" className="form-control" id="hourlyRate" value={hourlyRate} onChange={e => setHourlyRate(e.target.value)} placeholder="Hourly Rate" required />
                        </div>
                    </div>
           
                    <label htmlFor="photo" className="text-muted pb-1">Photo</label>
                    <input
                        type="file"
                        id="photo"
                        name="photo"
                        accept="image/*" // This restricts the file picker to image files
                        onChange={handleImageUpload}
                        className="form-control"
                    />
                    {photoUrl && (
                        <img src={photoUrl} alt="Babysitter" className=" w-50  my-2" style={{ height:'150px' }} />
                    )}
                    <button type="submit" className="btn btn-primary">Update Profile</button>
                </form>
            </div>
            <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
        </div>
    );
};

export default EditBabysitterProfile;