import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { jwtDecode } from "jwt-decode";
import Form from 'react-bootstrap/Form';
import { co } from '../../../node_modules/@fullcalendar/core/internal-common';


const Register = () => {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        username: '',
        password: '',
        role: 0, // Add role to the state
    });
    const [isValidated, setIsValidated] = useState(false);
    const [passwordError, setPasswordError] = useState('');

    const [loading, setLoading] = useState(false)
    const [error, setError] = useState("")

    const UserRole = {
        Customer: 0,
        BabySitter: 1
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        // Convert role to a number, but leave other fields as they are
        const updatedValue = name === 'role' ? +value : value;
        setFormData({
            ...formData,
            [name]: updatedValue,
        });
    };

    console.log(formData);

    const isValidPassword = (password) => {
        // Check for minimum length of 10 characters
        const specialCharacterRegex = /[ `!@#$%^&*()_+\-=[\]{};':"\\|,.<>/?~]/;
        const digitRegex = /\d/;
        const uppercaseRegex = /[A-Z]/;

        if (password.length < 10) {
            setPasswordError('Password must be more than 10 characters.\n');
        } else if (!specialCharacterRegex.test(password)) {
            setPasswordError('Password must contain a special character\n');
        } else if (!digitRegex.test(password)) {
            setPasswordError('Password must contain a digit.\n');
        } else if (!uppercaseRegex.test(password)) {
            setPasswordError('Password must contain an upper case letter.\n');
        } else {
            setPasswordError('');
        }
        return setIsValidated(true);
    };


    const handleSubmit = async (e) => {
        e.preventDefault();
       
        isValidPassword(formData.password);

        try {
            console.log('loading')
            setLoading(true)
            const response = await axios.post('https://localhost:7089/api/auth/register', formData);
            const { token, userId } = response.data;
            console.log(response.data);
            console.log(token);
            console.log(userId);

            localStorage.setItem('authToken', token); // save the token to localstorage
            localStorage.setItem('userId', userId); // Save the user ID

            //decode the token to get user Data
            const decoded = jwtDecode(token);
            console.log(decoded);
            //the role is in a claim called 'role'
            const userRole = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
            console.log(userRole);
            //redirect based on the role 
            if (userRole === 'Customer') {
                navigate('/customer-create-profile')
            } else if (userRole === 'BabySitter') {
                navigate('/babysitter-create-profile');
            } else {
                // handle unexpected roles or errors 
                console.error('Unknown role');
            }
            setError('')
        } catch (error) {
            console.error(error);
            setError('error')
            // Handle error (e.g., show error message)
        }finally {
            setLoading(false)
        }
    };

    return (
        <div className="vh-100">
            <nav className="navbar sticky-top bg-pink tex-center d-flex justify-content-center" >
                <div className="text-white p-1 fs-5 fst-italic">Welcome to Babysitter Anytime</div>
            </nav>
                <div className="col-sm-12 col-md-8 col-lg-4 mx-auto h-100 mt-5"> {/* mx-auto for horizontal centering */}
                    <div className="card">
                        <div className="card-body">
                            <h2 className="card-title text-center fs-3">Register</h2>
                            <form onSubmit={handleSubmit}>
                                <div className="form-group my-3">
                                    <label htmlFor="username">Username</label>
                                    <input
                                        type="text"
                                        required
                                        id="username"
                                        name="username"
                                        className="form-control"
                                        value={formData.username}
                                        onChange={handleChange}
                                    />
                                </div>
                                <div className="form-group my-3">
                                    <label htmlFor="password">Password</label>
                                    <input
                                        type="password"
                                        required
                                        id="password"
                                        name="password"
                                        className="form-control"
                                        value={formData.password}
                                        onChange={handleChange}
                                        placeholder="10 characters with a numeric, character and capital."
                                    />
                                </div>
                                {isValidated === true ? <div className="password-error-message">{passwordError}</div> : null}
                                <label htmlFor="role">Role</label>
                                <Form.Select id="role" value={formData.role} name="role" onChange={handleChange} aria-label="Default select example">
                                    {!formData.role && <option value="">Select a role</option>}
                                    <option value={UserRole.Customer}>Customer</option>
                                    <option value={UserRole.BabySitter}>BabySitter</option>
                                </Form.Select>
                                <div className="d-flex mt-3">
                                    <button type="submit" className={`btn  btn-sm btn-${error ? 'danger' : loading ? 'secondary' : 'primary'}`}>{loading ? 'loading...' : error ? 'Retry' : 'Register'}</button>
                                    <div className="ms-2 text-danger align-items-center">{error ? <div className="d-flex align-items-center">
                                        <svg
                                            viewBox="0 0 24 24"
                                            fill="red"
                                            height={21}
                                            width={21}
                                        >
                                            <path d="M11.001 10h2v5h-2zM11 16h2v2h-2z" />
                                            <path d="M13.768 4.2C13.42 3.545 12.742 3.138 12 3.138s-1.42.407-1.768 1.063L2.894 18.064a1.986 1.986 0 00.054 1.968A1.984 1.984 0 004.661 21h14.678c.708 0 1.349-.362 1.714-.968a1.989 1.989 0 00.054-1.968L13.768 4.2zM4.661 19L12 5.137 19.344 19H4.661z" />
                                        </svg> <div>Error registering</div> </div> : null}</div>

                                </div>
                            </form>
                        </div>
                    </div>
            </div>
            <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
        </div>
    );
};

export default Register;