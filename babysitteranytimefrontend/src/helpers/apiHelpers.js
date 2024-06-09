import axios from 'axios';

// This function assumes that the token is always available in localStorage when called.
export const fetchBabysitterByUserId = async (userId) => {
    try {
        const token = localStorage.getItem('authToken');
        if (!token) throw new Error('No auth token available.');
        console.log(token);
        console.log(userId);
        const response = await axios.get(`https://localhost:7089/api/Babysitter/GetBabysitterByUserId/${userId}`, {
            headers: {
                'Authorization': `Bearer ${token}`,
            },
        });

        return response.data; // This will be the babysitter object
    } catch (error) {
        console.error('Failed to fetch babysitter:', error);
        throw error; // Rethrow the error to handle it in the calling component
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

        return response.data; // This will be the customer object
    } catch (error) {
        console.error('Failed to fetch customer:', error);
        throw error; // Rethrow the error to handle it in the calling component
    }
};

