import axios from 'axios';

// This function assumes that the token is always available in localStorage when called.
export const fetchBabysitterByUserId = async (userId) => {
    try {
        const token = localStorage.getItem('authToken');
        if (!token) throw new Error('No auth token available.');

        const response = await axios.get(`https://localhost:7089/api/Babysitter/GetBabysitterByUserId/${userId}`, {
            headers: {
                'Authorization': `Bearer ${token}`,
            },
        });

        return response.data; 
    } catch (error) {
        console.error('Failed to fetch babysitter:', error);
        throw error; 
    }
};

export const fetchCustomerByUserId = async (userId) => {
    try {
        const token = localStorage.getItem('authToken');
        if (!token) throw new Error('No auth token available.');

        const response = await axios.get(`https://localhost:7089/api/Client/GetCustomerByUserId/${userId}`, {
            headers: {
                'Authorization': `Bearer ${token}`,
            },
        });

        return response.data; 
    } catch (error) {
        console.error('Failed to fetch customer:', error);
        throw error; 
    }
};

