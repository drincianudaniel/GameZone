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
import TextField from "@mui/material/TextField";
import { DesktopDateTimePicker } from '@mui/x-date-pickers/DesktopDateTimePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';

function GamesPage() {
  const [games, setGames] = useState([]);
  const [open, setOpen] = useState(false);
  const [name, setName] = useState("");
  const [date, setDate] = useState(new Date('2018-01-01T00:00:00.000Z'));
  const [details, setDetails] = useState("");
  const [imageSrc, setImageSrc] = useState("");

  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  const [selectedDevelopers, setSelectedDevelopers] = useState([]);
  const [selectedGenres, setSelectedGenres] = useState([]);
  const [selectedPlatforms, setSelectedPlatforms] = useState([]);
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
    display: "flex",
    justifyContent: "center",
    flexDirection:"column",
  };

  useEffect(() => {
    getGames();
  }, []);

  const getGames = async () => {
    await axios
      .get("https://localhost:7092/api/Games")
      .then((res) => setGames(res.data));
  };

  const getDevelopers = async () => {
    return await axios
      .get("https://localhost:7092/api/Developers")
      .then((res) => res.data);
  };

  const getGenres = async () => {
    return await axios
      .get("https://localhost:7092/api/Genres")
      .then((res) => res.data);
  };

  const getPlatforms = async () => {
    return await axios
      .get("https://localhost:7092/api/Platforms")
      .then((res) => res.data);
  };

  const createGame = async () => {

    const data = {
      name: name,
      releaseDate: date,
      imageSrc: imageSrc,
      gameDetails: details,
      developerList: selectedDevelopers.map(e => e.id),
      genreList: selectedGenres.map(e => e.id),
      platformList: selectedPlatforms.map(e => e.id),
    }

    await axios
    .post(`${process.env.REACT_APP_SERVERIP}/Games`, data)
    .then(response => {handleClose(); getGames()})
    .catch(err => console.log(err));
  }

  const handleChangeDevelopers = (event) => {
    const {
      target: { value },
    } = event;
    setSelectedDevelopers(value);
  };

  const handleChangeGenres = (event) => {
    const {
      target: { value },
    } = event;
    setSelectedGenres(value);
  };

  const handleChangePlatforms = (event) => {
    const {
      target: { value },
    } = event;
    setSelectedPlatforms(value);
  };

  return (
    <div className="gamePageContent">
      <Header />
      <Button variant="contained" onClick={handleOpen}>Add a new game</Button>
      <div className="games">
        {games.map((data, i) => {
          return (
            <div key={data.id}>
                <GameCard data={data} i={i} getGames={getGames} />
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
              <TextField
                sx={{ m: 1}}
                id="outlined-basic"
                label="Name"
                variant="outlined"
                value={name}
                onChange={e => setName(e.target.value)}
              />
              <TextField
                sx={{ m: 1}}
                id="outlined-basic"
                label="Game Details"
                variant="outlined"
                value={details}
                onChange={e => setDetails(e.target.value)}
              />
              <TextField
                sx={{ m: 1}}
                id="outlined-basic"
                label="Image Link"
                variant="outlined"
                value={imageSrc}
                onChange={e => setImageSrc(e.target.value)}
              />
              <LocalizationProvider dateAdapter={AdapterDateFns}>
                <DesktopDateTimePicker
                  sx={{ m: 1}}
                  label="Release Date"
                  value={date}
                  onChange={(newValue) => {
                    setDate(newValue);
                  }}
                  renderInput={(params) => <TextField {...params} />}
                />
              </LocalizationProvider>
              <MultipleSelectChip name="Developer" getData={getDevelopers} handleChange={handleChangeDevelopers} valueName={selectedDevelopers} />
              <MultipleSelectChip name="Genre" getData={getGenres} handleChange={handleChangeGenres} valueName={selectedGenres}/>
              <MultipleSelectChip name="Platform" getData={getPlatforms} handleChange={handleChangePlatforms} valueName={selectedPlatforms}/>
              <Button variant="contained" onClick={createGame}>Create Game</Button>
            </FormControl>
          </Box>
        </Fade>
      </Modal>
      <AppPagination></AppPagination>
    </div>
  );
}

export default GamesPage;