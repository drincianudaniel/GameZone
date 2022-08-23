import Header from "../components/Header";
import { useEffect, useState } from "react";
import axios from "axios";
import * as React from "react";
import GameCard from "../components/GameCard";
import AppPagination from "../components/AppPagination";
import "./css/GamesPage.css";
import { Link } from "react-router-dom";
import MultipleSelectChip from "../components/MultipleSelectChip";
import Backdrop from "@mui/material/Backdrop";
import Box from "@mui/material/Box";
import Modal from "@mui/material/Modal";
import Fade from "@mui/material/Fade";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import FormControl from "@mui/material/FormControl";

function GamesPage() {
  const [games, setGames] = useState([]);
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  //modal styles
  const style = {
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: 400,
    bgcolor: "background.paper",
    border: "2px solid #000",
    boxShadow: 24,
    p: 4,
  };

  useEffect(() => {
    getGames();
  }, []);

  const getGames = () => {
    axios
      .get("https://localhost:7092/api/Games")
      .then((res) => setGames(res.data));
  };

  const getDevelopers = async() => {
    return await axios
      .get("https://localhost:7092/api/Developers")
      .then((res) => res.data);
  };

  const getGenres = async() => {
    return await axios
      .get("https://localhost:7092/api/Genres")
      .then((res) => res.data);
  };

  const getPlatforms = async() => {
    return await axios
      .get("https://localhost:7092/api/Platforms")
      .then((res) => res.data);
  };

  return (
    <div className="gamePageContent">
      <Header />
      <Button onClick={handleOpen}>Add a new game</Button>
      <div className="games">
        {games.map((data, i) => {
          return (
            <div key={data.id}>
              <Link style={{ textDecoration: "none" }} to={`/game/${data.id}`}>
                <GameCard data={data} i={i} />
              </Link>
            </div>
          );
        })}
      </div>
      <Modal
        aria-labelledby="transition-modal-title"
        aria-describedby="transition-modal-description"
        open={open}
        onClose={handleClose}
        closeAfterTransition
        BackdropComponent={Backdrop}
        BackdropProps={{
          timeout: 500,
        }}
      >
        <Fade in={open}>
          <Box sx={style}>
            <Typography id="transition-modal-title" variant="h6" component="h2">
              Create Game
            </Typography>
            <FormControl>
              <MultipleSelectChip name="Developer" getData={getDevelopers}/>
              <MultipleSelectChip name="Genre" getData={getGenres}/>
              <MultipleSelectChip name="Platform" getData={getPlatforms}/>
            </FormControl>
          </Box>
        </Fade>
      </Modal>
      <AppPagination></AppPagination>
    </div>
  );
}

export default GamesPage;
