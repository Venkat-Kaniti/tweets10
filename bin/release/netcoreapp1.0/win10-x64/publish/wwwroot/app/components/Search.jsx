/// Presentaional Component For Filtering Tweets By Search Term.

import React, { PropTypes } from 'react';

const Search = (props) => {
    const { handleSearch } = props;
    return (
        <input
            className='form-control tweetsearch'
            type='text'
            placeholder='search..'
            onChange={e => {
                e.preventDefault();
                handleSearch(e.target.value);
            }
        }/>
    );
};

Search.propTypes = {
    handleSearch: PropTypes.func.isRequired
};

export default Search;