import * as React from "react";
import { useState, useEffect } from "react";
import { AsyncPaginate } from "react-select-async-paginate";
import "./css/AutoCompleteSearch.css";

function AutoCompleteSearch(props) {
  const [game, setGame] = useState();

  const handleSearch = (searchGame) => {
    setGame(searchGame);
    props.handleSearchGame(searchGame);
  };

  const loadOptions = async (gameSearched, callback) => {
    if (gameSearched.length > 1) {
      const data = fetch(
        `${process.env.REACT_APP_SERVERIP}/games/auto-complete/${gameSearched}`
      )
        .then((res) => res.json())
        .then((res) => {
          return {
            options: res.map((element) => {
              return {
                value: element.id,
                label: element.name,
              };
            }),
          };
        })
        .catch((err) => console.log(err));
      return data;
    } else {
      callback(null);
    }
  };
  return (
    <AsyncPaginate
      placeholder="Search"
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
