import React, {useState, useEffect} from 'react';
import { FiArrowLeft, FiPower, FiEdit, FiTrash2 } from 'react-icons/fi'
import { Link, useHistory } from 'react-router-dom';

import api from '../../services/api';

import './styles.css';

import logoImage from '../../assets/logo.svg';

export default function Person(){

    const [persons, setPersons] = useState([]);
    const [page, setPage] = useState(1);

    const userName = localStorage.getItem('userName');
    const accessToken = localStorage.getItem('accessToken');

    const history = useHistory();

    const authorization = {
        headers: {
            Authorization: `Bearer ${accessToken}`
        }
    };

    useEffect(() => {
        fetchMorePersons();
    }, [accessToken]);

    async function fetchMorePersons() {
        const response = await api.get(`api/Person/v1/asc/4/${page}`, authorization);
        setPersons([ ...persons, ...response.data.list]);
        setPage(page + 1);
    }

    async function logout(){
        try {
            await api.get('api/auth/v1/revoke', authorization);

            localStorage.clear();
            history.push('/')
        } catch(error) {
            alert('Logout failed! Try Again!')
        }
    }

    async function editPerson(id){
        try {
            history.push(`person/new/${id}`);
        } catch (error) {
            alert('Edit person failed! Try Again!');
        }
    }

    async function deletePerson(id) {
        try {
            await api.delete(`api/person/v1/${id}`, authorization)
            
            setPersons(persons.filter(person => person.id !== id))
        } catch (error) {
            alert('Error deleting person! Try Again!')
        }
    }


    return (
        <div className="person-container">
            <header>
                <img src={logoImage} alt="Erudio"/>
                <span>Welcome, <strong>{userName.toLowerCase()}</strong>!</span>
                <Link className="back-link" to="/selector">
                        <FiArrowLeft size={16} color="#251fc5"/>
                        Back to Selector
                </Link>
                <Link className="button" to="person/new/0">Add New Person</Link>
                <button onClick={logout} type="button">
                    <FiPower size={18} color="#251FC5" />
                </button>
            </header>

            <h1>Registered Persons</h1>

            <ul>
                {persons.map(person => (
                    <li key={person.id}>
                        <strong>Name</strong>
                        <p>{person.firstName} {person.lastName}</p>
                        <strong>Gender:</strong>
                        <p>{person.gender}</p>
                        <strong>Address:</strong>
                        <p>{person.address}</p>

                        <button onClick={() => editPerson(person.id)} type="button">
                            <FiEdit size={20} color="#251FC5"/>
                        </button>

                        <button onClick={() => deletePerson(person.id)} type="button">
                            <FiTrash2 size={20} color="#251FC5"/>
                        </button>
                    </li>
                ))}
            </ul>
            <button className="button" onClick={fetchMorePersons} type="button">Load More</button>
        </div>
    );
}