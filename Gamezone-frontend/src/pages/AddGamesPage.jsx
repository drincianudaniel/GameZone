import Header from "../components/Header";
import axios from "axios";
import { useEffect, useState } from "react";
import "./css/TopPage.css";
import MultipleSelectChip from "../components/MultipleSelectChip";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import FormControl from "@mui/material/FormControl";
import TextField from "@mui/material/TextField";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import TextareaAutosize from "@mui/material/TextareaAutosize";
import "./css/AddGamesPage.css";

function AddGamesPage() {
  const [selectedDevelopers, setSelectedDevelopers] = useState([]);
  const [selectedGenres, setSelectedGenres] = useState([]);
  const [selectedPlatforms, setSelectedPlatforms] = useState([]);
  const [name, setName] = useState("");
  const [date, setDate] = useState(new Date("2018-01-01T00:00:00.000Z"));
  const [details, setDetails] = useState("");
  const [imageSrc, setImageSrc] = useState("");

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

  const createGame = async () => {
    const data = {
      name: name,
      releaseDate: date,
      imageSrc: imageSrc,
      gameDetails: details,
      developerList: selectedDevelopers.map((e) => e.id),
      genreList: selectedGenres.map((e) => e.id),
      platformList: selectedPlatforms.map((e) => e.id),
    };

    await axios
      .post(`${process.env.REACT_APP_SERVERIP}/Games`, data)
      .then((response) => {})
      .catch((err) => console.log(err));
  };

  const getDevelopers = async () => {
    return await axios
      .get(`${process.env.REACT_APP_SERVERIP}/Developers`)
      .then((res) => res.data);
  };

  const getGenres = async () => {
    return await axios
      .get(`${process.env.REACT_APP_SERVERIP}/Genres`)
      .then((res) => res.data);
  };

  const getPlatforms = async () => {
    return await axios
      .get(`${process.env.REACT_APP_SERVERIP}/Platforms`)
      .then((res) => res.data);
  };

  return (
    <div className="content">
      <Header />

      <div className="form">
        <FormControl>
          <TextField
            required
            sx={{ m: 1 }}
            id="outlined-basic"
            label="Name"
            variant="outlined"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
          <TextareaAutosize
            required
            aria-label="empty textarea"
            placeholder="Game Details"
            style={{
              margin: 10,
              minHeight: 56,
              maxWidth: 500,
              minWidth: 500,
              fontSize: 15,
            }}
            value={details}
            onChange={(e) => setDetails(e.target.value)}
          />
          <TextField
            required
            sx={{ m: 1 }}
            id="outlined-basic"
            label="Image Link"
            variant="outlined"
            value={imageSrc}
            onChange={(e) => setImageSrc(e.target.value)}
          />

          <LocalizationProvider dateAdapter={AdapterDateFns}>
            <DesktopDatePicker
              required
              sx={{ m: 1 }}
              label="Release Date"
              value={date}
              onChange={(newValue) => {
                setDate(newValue);
              }}
              renderInput={(params) => <TextField {...params} />}
            />
          </LocalizationProvider>
          <MultipleSelectChip
            name="Developer"
            getData={getDevelopers}
            handleChange={handleChangeDevelopers}
            valueName={selectedDevelopers}
          />
          <MultipleSelectChip
            name="Genre"
            getData={getGenres}
            handleChange={handleChangeGenres}
            valueName={selectedGenres}
          />
          <MultipleSelectChip
            name="Platform"
            getData={getPlatforms}
            handleChange={handleChangePlatforms}
            valueName={selectedPlatforms}
          />
          <Button variant="contained" onClick={createGame}>
            Create Game
          </Button>
        </FormControl>
      </div>
    </div>
  );
}
export default AddGamesPage;
