import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import Book from './pages/Book';
import Login from './pages/Login';
import NewBook from './pages/NewBook';
import Person from './pages/Person';
import NewPerson from './pages/NewPerson';
import Selector from './pages/Selector';

export default function Routes(){
    return(
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Login}/>
                <Route path="/books" component={Book}/>
                <Route path="/book/new/:bookId" component={NewBook}/>
                <Route path="/persons" component={Person}/>
                <Route path="/person/new/:personId" component={NewPerson}/>
                <Route path="/selector" component={Selector}/>
            </Switch>
        </BrowserRouter>
    );
}