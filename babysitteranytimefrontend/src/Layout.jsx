import React from 'react';
import { useNavigate, useLocation } from 'react-router-dom'; 
import axios from 'axios';
import DropdownMenu from './menu/DropdownMenu';


const Layout = ({ children, userType }) => {
    const navigate = useNavigate();
    const location = useLocation();
    const excludedPaths = ['/', '/register', '/login'];

    const logout = async () => {
        const token = localStorage.getItem('authToken');
            await axios.post('https://localhost:7089/api/auth/logout', {}, {
                headers: { 'Authorization': `Bearer ${token}` }
            });
            localStorage.removeItem('authToken');
            localStorage.removeItem('userId');
            navigate('/login');
        };

        const handleProfileClick = async () => {
        const userId = localStorage.getItem('userId');
          // You are missing the fetchBabysitterByUserId function (line 25) - it is not defined anywhere
        const babysitterData = await fetchBabysitterByUserId(userId);
        if (babysitterData && babysitterData.id) {
            navigate(`/babysitter-profile/${babysitterData.id}`);
        }
    };

    const showMenu = !excludedPaths.includes(location.pathname);
    const menuOptions = userType === 'Customer' ? [
        { label: 'Edit Profile', action: () => navigate('/customer-edit-profile') },
        { label: 'Appointment History', action: () => navigate('/customer-appointment-history') },
        { label: 'Logout', action: logout },
    ] : [
        { label: 'Profile', action: handleProfileClick },
        { label: 'Edit Profile', action: () => navigate('/babysitter-edit-profile') },
        { label: 'Appointment History', action: () => navigate('/babysitter-appointment-history') },
        { label: 'Logout', action: logout },
    ];

    return (
        <div >
            {showMenu && <DropdownMenu options={menuOptions} />}
                {children}
        </div>
    );
};

export default Layout;