import React, {useState, useEffect} from 'react';
import { FiPower, FiEdit, FiTrash2 } from 'react-icons/fi'

import api from '../../services/api';

import './styles.css';

import logoImage from '../../assets/logo.svg';

export default function Book(){
    return (
        <div className="book-container">
            <header>
                <img src={logoImage} alt="Erudio"/>
                <span>Welcome, <strong>user</strong>!</span>
                <button onClick="" type="button">
                    <FiPower size={18} color="#251FC5" />
                </button>
            </header>

            <h1>Registered Books</h1>

            <ul>
                {/*Listagem de Livros via API*/}
                <li>
                    <strong>Title:</strong>
                    <p>*Book's Title*</p>
                    <strong>Author:</strong>
                    <p>*Book's Author*</p>
                    <strong>Price:</strong>
                    <p>*Book's Price*</p>
                    <strong>Release Date:</strong>
                    <p>*Book's Release Date*</p>

                    {/*Editar o livro registrado via API*/}
                    <button onClick="" type="button">
                        <FiEdit size={20} color="#251FC5"/>
                    </button>

                    {/*Deletar o livro registrado via API*/}
                    <button onClick="" type="button">
                        <FiTrash2 size={20} color="#251FC5"/>
                    </button>
                </li>
            </ul>
        </div>
    );
}