import React, { useState } from 'react';
import './DropdownMenu.css'; // your custom CSS for styling

const DropdownMenu = ({ options }) => {
    const [isOpen, setIsOpen] = useState(false);

    const toggleMenu = () => {
        setIsOpen(!isOpen);
    };

    console.log('Options:', options);
    return (
        <div className="dropdown-menu-container">
            <button onClick={toggleMenu} className="dropdown-toggle">Menu</button>
            {isOpen && (
                <ul className={`dropdown-menu ${isOpen ? 'open' : ''}`}>
                    {options.map(option => (
                        <li key={option.label} onClick={option.action}>{option.label}</li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default DropdownMenu;