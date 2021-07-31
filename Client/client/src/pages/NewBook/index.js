import React, { useEffect, useState } from 'react';
import { Link, useHistory, useParams } from 'react-router-dom';
import { FiArrowLeft } from 'react-icons/fi'

import api from '../../services/api';

import './styles.css';

import logoImage from '../../assets/logo.svg';

export default function NewBook(){
    return(
        <div className="new-book-container">
            <div className="content">
                <section className="form">
                    <img src={logoImage} alt="Erudio"/>
                    <h1>*Add or Update Book*</h1>
                    <p>Enther the book information and click on *Add or Update*</p>
                    <Link className="back-link" to="/books">
                        <FiArrowLeft size={16} color="#251fc5"/>
                        Back to Books
                    </Link>
                </section>

                <form onSubmit="">
                    <input 
                        placeholder = "Title"
                        value=""
                        onChange="" 
                    />
                    <input 
                        placeholder = "Author"
                        value=""
                        onChange="" 
                    />
                    <input 
                        type = "date"
                        value=""
                        onChange="" 
                    />
                    <input 
                        placeholder = "Price"
                        value=""
                        onChange="" 
                    />
                    <button className="button" type="submit">*Add or Update*</button>
                </form>
            </div>
        </div>
    );
}