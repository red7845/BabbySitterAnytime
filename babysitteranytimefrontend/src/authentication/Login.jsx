import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { jwtDecode } from "jwt-decode";

const Login = () => {
    const [credentials, setCredentials] = useState({
        username: '',
        password: '',
    });
    const navigate = useNavigate();
    const [loading, setLoading] = useState(false)
    const [error, setError] = useState("")

    const handleChange = (e) => {
        setCredentials({
            ...credentials,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            // Replace with your actual login API endpoint
            console.log('loading')
            setLoading(true)
            const response = await axios.post('https://localhost:7089/api/auth/login', credentials);
            console.log(response.data);
            const { token, userId } = response.data;
            localStorage.setItem('authToken', token); // save the token to localstorage
            localStorage.setItem('userId', userId); // Save the user ID

            //decode the token to get user Data
            const decoded = jwtDecode(token);

            //the role is in a claim called 'role'
            const userRole = decoded.role;
            console.log(userRole);
            console.log(response.data);
            console.log(decoded);
            console.log(decoded?.unique_name||"")
            localStorage.setItem('customerName', decoded?.unique_name || ""); // Save the user name
            //redirect based on the role 
            if (userRole === 'Customer') {
                navigate('/customer-home')
            } else if (userRole === 'BabySitter') {
                navigate('/babysitter-home');
            } else {
                // handle unexpected roles or errors 
                console.error('Unknown role');
            }
            setError('')
        } catch (error) {
            console.error(error);
            setError('error')
            // Handle login error (e.g., show error message)
        } finally {
            setLoading(false)
            console.log('loading false')
        }
    };
    //Giannis
    //Aaaaaaaaaa13@

    return (
        <div className="vh-100">
            <nav className="navbar sticky-top bg-pink tex-center d-flex justify-content-center" > 
               <div className="text-white p-1 fs-5 fst-italic">Welcome to Babysitter Anytime</div>
            </nav>
      <div  className="rounded h-100 d-flex justify-content-center align-items-center">
                <div className="card mb-auto mt-5" style={{ width: '100%', maxWidth: '360px', padding: '20px', boxShadow: '0 4px 8px rgba(1,0,0,0.1)' }}>
                    <div className="card-body p-0">
                        <h2 className="card-title text-center fs-3">Login</h2>
                        <form onSubmit={handleSubmit}>
                            <div className="form-group my-3">
                                <label htmlFor="username">Username</label>
                                <input
                                    type="text"
                                    id="username"
                                    name="username"
                                    className="form-control"
                                    value={credentials.username}
                                    onChange={handleChange}
                                    required
                                />
                            </div>
                            <div className="form-group my-3">
                                <label htmlFor="password">Password</label>
                                <input
                                    type="password"
                                    id="password"
                                    name="password"
                                    className="form-control"
                                    value={credentials.password}
                                    onChange={handleChange}
                                    required
                                />
                            </div>
                            <div className="d-flex">
                                <button type="submit" className={`btn  btn-sm btn-${error ? 'danger' : loading ? 'secondary' : 'primary'}`}>{loading ? 'logging in...' : error ? 'Retry' : 'Login'}</button>
                                <div className="ms-2 text-danger align-items-center">{error ? <div className="d-flex align-items-center">
                                    <svg
                                        viewBox="0 0 24 24"
                                        fill="red"
                                        height={21}
                                        width={21 }
                                >
                                    <path d="M11.001 10h2v5h-2zM11 16h2v2h-2z" />
                                    <path d="M13.768 4.2C13.42 3.545 12.742 3.138 12 3.138s-1.42.407-1.768 1.063L2.894 18.064a1.986 1.986 0 00.054 1.968A1.984 1.984 0 004.661 21h14.678c.708 0 1.349-.362 1.714-.968a1.989 1.989 0 00.054-1.968L13.768 4.2zM4.661 19L12 5.137 19.344 19H4.661z" />
                                </svg> <div>Error loging in</div> </div> : null}</div>
                         
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <footer className="sticky-bottom bg-pink text-light p-2 text-center">&#169; Copyright 2024 Redina. All rights reserved</footer>
        </div>
    );
};

export default Login;