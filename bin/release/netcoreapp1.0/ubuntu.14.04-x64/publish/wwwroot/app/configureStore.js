/// Creates & Configures App's Store. Adds Of Middleware

import thunkMiddleware from 'redux-thunk';
import { createStore, applyMiddleware } from 'redux';
import tweet10App from './reducers';

const configureStore = () => {
    return createStore(tweet10App, applyMiddleware(thunkMiddleware));
};

export default configureStore;