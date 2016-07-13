/// Presentational Component For Displaying All Tweets

import bootstrapCss from '../css/bootstrap.min.css';
import style from '../css/site.css';

import React, { PropTypes } from 'react';

const Tweets = ({ user, tweets }) => {
    console.log(tweets);
    return (
        <div>
            {
                tweets.length > 0 ?
                    tweets.map(
                        tweet => {
                            return (
                                <div className='row tweet' key={tweet.id}>

                                    <div className='col-xs-2 img-circle avatar'>
                                        <img
                                            className='img-rounded'
                                            src={user.profileImageUrl} alt={user.screenName}/>
                                    </div>

                                    <div className='col-xs-10'>
                                        <div className='tweet-header'>
                                            <h5 className='col-xs-12 col-sm-8 pull-left'>
                                                <strong> @{user.screenName}</strong>{' '}
                                                <small>({user.name}) </small>
                                            </h5>
                                            <h6 className='col-xs-12 col-sm-4 text-center pull-right label-as-badge'>
                                                {tweet.retweetCount} Retweets
                                            </h6>
                                        </div>
                                        <p className='tweet-text'>
                                            {tweet.text}
                                        </p>
                                    </div>

                                </div>
                            );
                        }
                    ) :
                    'No Tweets.!'
            }
        </div>
    );
};

Tweets.propTypes = {
    user: PropTypes.shape({
        name: PropTypes.string,
        screenName: PropTypes.string,
        profileImageUrl: PropTypes.string
    }).isRequired,

    tweets: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.string.isRequired,
        text: PropTypes.string.isRequired,
        retweetCount: PropTypes.number.isRequired
    }).isRequired).isRequired
};

export default Tweets;