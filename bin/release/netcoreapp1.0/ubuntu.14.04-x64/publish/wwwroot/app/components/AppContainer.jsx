/// Container Component For Passing Data to Presentational Compoents.
/// Holds Behaviour Of The App.

import React, { Component } from 'react';
import { connect } from 'react-redux';

import { requestTweets, updateSearch } from '../actions';
import Tweets from './Tweets.jsx';
import Search from './Search.jsx';

class AppContainer extends Component {
    constructor(props) {
        super(props);

        this._handleSearch = this._handleSearch.bind(this);
        this._filterTweets = this._filterTweets.bind(this);
    }

    componentDidMount() {
        const { dispatch } = this.props;

        this._timer = setInterval(() => {
            this.props.dispatch(requestTweets());
        }, 60 * 1000);

        dispatch(requestTweets());
    }

    componentWillUnmount() {
        clearInterval(this._timer);
    }

    _handleSearch(searchTerm) {
        const { dispatch } = this.props;
        dispatch(updateSearch(searchTerm));
    }

    _filterTweets() {
        const { searchTerm, tweets} = this.props;
        return tweets.filter(t => {
            return t.text.toLowerCase().includes(searchTerm.toLowerCase());
        });
    }

    render() {
        const { user } = this.props;
        return (
            <div>
                <Search handleSearch = {this._handleSearch}/>
                <Tweets user={ user } tweets={ this._filterTweets() } />
            </div>
        );
    }
}

const mapStateToProps = (state) => {

    return {
        user: state.user,
        tweets: state.tweets,
        searchTerm: state.searchTerm
    };
};

export default connect(mapStateToProps)(AppContainer);