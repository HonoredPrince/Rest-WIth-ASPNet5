import React, { useEffect, useState } from 'react';
import { Link, useHistory, useParams } from 'react-router-dom';
import { FiArrowLeft } from 'react-icons/fi'

import api from '../../services/api';

import './styles.css';

import logoImage from '../../assets/logo.svg';

export default function NewPerson(){

    const [id, setId] = useState(null);
    const [address, setAddress] = useState('');
    const [firstName, setFirstName] = useState('');
    const [gender, setGender] = useState('');
    const [lastName, setLastName] = useState('');

    const {personId} = useParams();

    const history = useHistory();

    const accessToken = localStorage.getItem('accessToken');

    const authorization = {
        headers: {
            Authorization: `Bearer ${accessToken}`
        }
    };

    useEffect(() => {
        if(personId === '0') return;
        else loadPerson();
    }, personId);

    async function loadPerson() {
        try {
            const response = await api.get(`api/person/v1/${personId}`, authorization)

            setId(response.data.id);
            setAddress(response.data.address);
            setFirstName(response.data.firstName);
            setGender(response.data.gender);
            setLastName(response.data.lastName);
        } catch (error) {
            alert('Error recovering Person! Try Again!')
            history.push('/persons');
        }
    }

    async function saveOrUpdate(e) {
        e.preventDefault();

        const data = {
            address,
            firstName,
            gender,
            lastName
        }

        try {
            if(personId === '0') {
                await api.post('api/Person/v1', data, authorization);
            } else {
                data.id = id;
                await api.put('api/Person/v1', data, authorization);
            }
        } catch (err) {
            alert('Error while recording Person! Try again!')
        }
        history.push('/persons');
    }

    return(
        <div className="new-person-container">
            <div className="content">
                <section className="form">
                    <img src={logoImage} alt="Erudio"/>
                    <h1>{personId === '0'? 'Add New' : 'Update'} Person</h1>
                    <p>Enter the person information and click on {personId === '0'? `'Add'` : `'Update'`}!</p>
                    <Link className="back-link" to="/persons">
                        <FiArrowLeft size={16} color="#251fc5"/>
                        Back to Persons
                    </Link>
                </section>

                <form onSubmit={saveOrUpdate}>
                    <input 
                        placeholder = "First Name"
                        value={firstName}
                        onChange={e => setFirstName(e.target.value)} 
                    />
                    <input 
                        placeholder = "Last Name"
                        value={lastName}
                        onChange={e => setLastName(e.target.value)}
                    />
                    <input 
                        placeholder = "Gender"
                        value={gender}
                        onChange={e => setGender(e.target.value)}
                    />
                    <input 
                        placeholder = "Address"
                        value={address}
                        onChange={e => setAddress(e.target.value)}
                    />
                    <button className="button" type="submit">{personId === '0'? 'Add' : 'Update'}</button>
                </form>
            </div>
        </div>
    );
}