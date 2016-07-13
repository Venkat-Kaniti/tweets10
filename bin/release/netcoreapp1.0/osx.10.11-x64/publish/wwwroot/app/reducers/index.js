/// Redux Reducer Of The App. Represents The App State.

const initialState = {
    user: {},
    tweets: [],
    searchTerm: ''
};

const tweet10App = (state = initialState, action) => {

    switch (action.type) {

        case 'RECEIVE_TWEETS':
            return Object.assign({}, state, {
                user: action.user,
                tweets: action.tweets
            });

        case 'UPDATE_SEARCH':
            return Object.assign({}, state, {
                searchTerm: action.searchTerm
            });

        default:
            return state;

    }
};

export default tweet10App;