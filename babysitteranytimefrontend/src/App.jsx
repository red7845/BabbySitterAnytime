import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { jwtDecode } from "jwt-decode"; 
import Layout from './Layout';
import HomePage from './HomePage';
import Login from './authentication/Login';
import Register from './authentication/Register';
import CustomerHomePage from './customer_pages/CustomerHomePage';
import BabysitterHomePage from './babysitter_pages/BabysitterHomePage';
import CustomerCreateProfile from './customer_pages/CustomerCreateProfile';
import EditCustomerProfile from './customer_pages/EditCustomerProfile';
import BabysitterProfile from './babysitter_pages/BabysitterProfile';
import BabySitterCreateProfile from './babysitter_pages/BabySitterCreateProfile';
import EditBabysitterProfile from './babysitter_pages/EditBabysitterProfile';
import BabysitterAppointmentHistory from './babysitter_pages/BabysitterAppointmentHistory';
import CustomerAppointmentHistory from './customer_pages/CustomerAppointmentHistory';
import 'bootstrap/dist/css/bootstrap.css';

const App = () => {
    const [userRole, setUserRole] = useState('');

    useEffect(() => {
        console.log('use effect')
        try {
            const token = localStorage.getItem('authToken');
            if (token) {
                console.log('from layout token:', token); // Properly log the token
                const decodedToken = jwtDecode(token);
                console.log('from layout decodedToken:', decodedToken); // Properly log the decoded token
                setUserRole(decodedToken.role);
                console.log(decodedToken.role)
            } else {
                console.log('No token available');
            }
        } catch (error) {
            console.error('Error decoding token:', error);
        }
    }, []);

    return (
        <Router>
            <Layout userType={userRole}>
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/login" element={<Login role={userRole} setUserRole={setUserRole } />} />
                    <Route path="/register" element={<Register setUserRole={setUserRole} />} />
                    <Route path="/customer-home" element={<CustomerHomePage />} />
                    <Route path="/babysitter-home" element={<BabysitterHomePage />} />
                    <Route path="/babysitter-profile/:babysitterId" element={<BabysitterProfile />} />
                    <Route path="/babysitter-create-profile" element={<BabySitterCreateProfile />} />
                    <Route path="/customer-create-profile" element={<CustomerCreateProfile />} />
                    <Route path="/customer-edit-profile" element={<EditCustomerProfile />} />
                    <Route path="/babysitter-edit-profile" element={<EditBabysitterProfile />} />
                    <Route path="/babysitter-appointment-history" element={<BabysitterAppointmentHistory />} />
                    <Route path="/customer-appointment-history" element={<CustomerAppointmentHistory />} />
                </Routes>
                </Layout>
        </Router>
    );
};

export default App;