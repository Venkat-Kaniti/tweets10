/// Actions Creators

import $ from 'jquery';

const receiveTweets = (result) => {
	return {
		type: 'RECEIVE_TWEETS',
		user: result.user,
		tweets: result.tweets
	};
};


export const updateSearch = (searchTerm) => {
	return { type: 'UPDATE_SEARCH', searchTerm };
};

export const requestTweets = () => {
	return dispatch => {
		return $.getJSON('/api/tweets')
			.done((result) => {
				dispatch(receiveTweets(result));
			});
	};
};
