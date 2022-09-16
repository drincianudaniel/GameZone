import Header from "../components/Header";
import * as React from "react";
import "./css/GamesPage.css";
import AddBoxIcon from "@mui/icons-material/AddBox";
import { IconButton } from "@mui/material";
import { Link } from "react-router-dom";
import Games from "../components/Games/Games";
import { GamesContextProvider } from "../ContextProvider/GamesContextProvider";



function GamesPage() {
  //const {data, isLoading, errors} = useQuery('/Games');

  // is Loading  = true
  // finally flase
  // return {data: data, isLoading, error ""}

  // const getGames = async () => {
  //   await axios
  //     .get(
  //       `${process.env.REACT_APP_SERVERIP}/games/page/${page}/page-size/${8}`
  //     )
  //     .then((res) => {
  //       setGames(res.data.data);
  //       setNumberOfPages(res.data.totalPages);
  //     })
  //     .catch();
  // };

  return (
    <div className="gamePageContent">
      <Header />
      <div className="subheader">
        <IconButton className="addButton" size="large">
          <Link style={{ textDecoration: "none", color: "black" }} to={`/add`}>
            {" "}
            <AddBoxIcon fontSize="large" sx={{ color: "white" }} />{" "}
          </Link>
        </IconButton>
      </div>
      <div className="nav"></div>
      <GamesContextProvider>
        <Games></Games>
      </GamesContextProvider>
    </div>
  );
}

export default GamesPage;
