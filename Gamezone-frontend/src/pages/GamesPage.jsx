import Header from "../components/Header";
import * as React from "react";
import "./css/GamesPage.css";
import AddBoxIcon from "@mui/icons-material/AddBox";
import { IconButton } from "@mui/material";
import { Link } from "react-router-dom";
import Games from "../components/Games/Games";



function GamesPage() {

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
        <Games/>
    </div>
  );
}

export default GamesPage;
