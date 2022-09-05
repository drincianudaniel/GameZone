import * as React from "react";
import { useState, useEffect } from "react";
import { AsyncPaginate } from 'react-select-async-paginate';

function AutoCompleteSearch(props) {
  const [game, setGame] = useState();

  const handleSearch = (searchGame) =>{
    setGame(searchGame);
    props.handleSearchGame(searchGame);
 }

  const loadOptions = async (gameSearched, callback) =>{
    if (gameSearched.length > 1) {
    const data = fetch(`https://localhost:7092/api/games/auto-complete/${gameSearched}`)
    .then( res => res.json())
    .then( res => {
        return {options: res.map(element => {
            return {
                value: element,
                label: element
            };
        }),
    }
    })
    .catch(err => console.log(err));
    return data;
}else{
    callback(null);
}
}
  return (
    <AsyncPaginate
      placeholder="Search for a game"
      value={game}
      debounceTimeout={600}
      onChange={handleSearch}
      loadOptions={loadOptions}
      className="searchbar"
      style={{ padding: "0px" }}
    />
  );
}
export default AutoCompleteSearch;
