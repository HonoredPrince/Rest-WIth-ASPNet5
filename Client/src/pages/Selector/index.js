import React from 'react';
import { useHistory } from 'react-router-dom';

import './styles.css';

import logoImage from '../../assets/logo.svg'

export default function Selector() {

    const history = useHistory();

    return (
        <div className="selector-container">
            <section className="form">
                <img src={logoImage} alt="Erudio Logo"/>
                <h1>Select a page</h1>
                <button className="button" onClick={() => {
                    history.push('/books')
                }}>Books</button>
                <button className="button" onClick={() => {
                    history.push('/persons')
                }}>Persons</button>
            </section>
        </div>
    )

}