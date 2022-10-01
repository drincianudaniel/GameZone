import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import axios from "axios";
import Grid from "@mui/material/Grid";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import MultipleSelectChip from "../MultipleSelectChip";
import { Autocomplete, Box } from "@mui/material";
import { useNavigate } from "react-router";
import { uploadFile } from "../../utils/UploadFile";
import { v4 as uuidv4 } from "uuid";
import GenreService from "../../api/GenreService";
import PlatformService from "../../api/PlatformService";
import DeveloperService from "../../api/DeveloperService";
import GameService from "../../api/GameService";

function AddGameForm() {
  const [date, setDate] = useState(new Date("2018-01-01T00:00:00.000Z"));

  const [developers, setDevelopers] = useState([]);
  const [genres, setGenres] = useState([]);
  const [platforms, setPlatforms] = useState([]);

  const [selectedDevelopers, setSelectedDevelopers] = useState([]);
  const [selectedGenres, setSelectedGenres] = useState([]);
  const [selectedPlatforms, setSelectedPlatforms] = useState([]);
  const history = useNavigate();

  useEffect(() => {
    getDevelopersSearch();
    getGenresSearch();
    getPlatformsSearch();
  }, []);

  const getDevelopersSearch = async () => {
    DeveloperService.getDevelopers().then((res) => {
      setDevelopers(res.data);
    });
  };

  const getGenresSearch = async () => {
    GenreService.getGenres().then((res) => {
      setGenres(res.data);
    });
  };

  const getPlatformsSearch = async () => {
    PlatformService.getPlatforms().then((res) => {
      setPlatforms(res.data);
    });
  };

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    console.log(data);
    let uniqueId = uuidv4();
    uploadFile(data.imgSrc[0], uniqueId);
    console.log(uniqueId);

    const dataToPost = {
      name: data.Name,
      releaseDate: date,
      imageSrc: `https://gamezone.blob.core.windows.net/files/${data.imgSrc[0].name}${uniqueId}`,
      gameDetails: data.Details,
      developerList: selectedDevelopers.map((e) => e.id),
      genreList: selectedGenres.map((e) => e.id),
      platformList: selectedPlatforms.map((e) => e.id),
    };

    GameService.postGame(dataToPost)
      .then((response) => {
        reset();
        history(`/game/${response.data.id}/comments`);
      })
      .catch((err) => console.log(err));
  };

  return (
    <Box
      sx={{ width: "100%", mt: 3 }}
      display="flex"
      justifyContent="center"
      alignItems="center"
    >
      <form noValidate autoComplete="off" onSubmit={handleSubmit(submit)}>
        <Grid container spacing={2} maxWidth={400}>
          <Grid item xs={12} md={12}>
            <TextField
              fullWidth
              required
              sx={{ marginBottom: 1 }}
              label="Name"
              name="Name"
              id="fullWidth outlined-multiline-static"
              {...register("Name", {
                required: { value: true, message: "Name is required" },
                maxLength: { value: 50, message: "Name is too long" },
              })}
              error={!!errors.Name}
              helperText={errors.Name?.message}
            />
          </Grid>

          <Grid item xs={12} md={12}>
            <TextField
              fullWidth
              multiline
              required
              rows={4}
              sx={{ marginBottom: 1 }}
              label="Details"
              name="Details"
              id="fullWidth outlined-multiline-static"
              {...register("Details", {
                required: { value: true, message: "Details is required" },
                minLength: {
                  value: 20,
                  message: `Details too short, min 20 characters`,
                },
                maxLength: { value: 1000, message: "Details is too long" },
              })}
              error={!!errors.Details}
              helperText={errors.Details?.message}
            />
          </Grid>

          <Grid item xs={12} md={12}>
            <TextField
              fullWidth
              required
              type="file"
              sx={{ marginBottom: 1 }}
              name="imgSrc"
              id="upload-photo"
              {...register("imgSrc", {
                required: { value: true, message: "Image is required" },
              })}
              error={!!errors.imgSrc}
              helperText={errors.imgSrc?.message}
            />
          </Grid>

          <LocalizationProvider dateAdapter={AdapterDateFns}>
            <DesktopDatePicker
              label="Release Date"
              value={date}
              onChange={(newValue) => {
                setDate(newValue);
              }}
              renderInput={(params) => (
                <Grid item xs={12} md={12}>
                  {" "}
                  <TextField
                    fullWidth
                    name="Date"
                    {...params}
                    {...register("Date", {
                      required: {
                        value: true,
                        message: "Release date is required",
                      },
                    })}
                  />{" "}
                </Grid>
              )}
            />
          </LocalizationProvider>

          <Grid item xs={12} md={12}>
            <Autocomplete
              value={selectedDevelopers}
              onChange={(event, newValue) => {
                setSelectedDevelopers(newValue);
                console.log(selectedDevelopers);
              }}
              multiple
              id="tags-outlined"
              options={developers}
              getOptionLabel={(option) => option.name}
              filterSelectedOptions
              renderInput={(params) => (
                <TextField {...params} label="Search Developers" />
              )}
            />
          </Grid>

          <Grid item xs={12} md={12}>
            <Autocomplete
              value={selectedGenres}
              onChange={(event, newValue) => {
                setSelectedGenres(newValue);
                console.log(selectedDevelopers);
              }}
              multiple
              id="tags-outlined"
              options={genres}
              getOptionLabel={(option) => option.name}
              filterSelectedOptions
              renderInput={(params) => (
                <TextField {...params} label="Search Genre" />
              )}
            />
          </Grid>

          <Grid item xs={12} md={12}>
            <Autocomplete
              value={selectedPlatforms}
              onChange={(event, newValue) => {
                setSelectedPlatforms(newValue);
                console.log(selectedDevelopers);
              }}
              multiple
              id="tags-outlined"
              options={platforms}
              getOptionLabel={(option) => option.name}
              filterSelectedOptions
              renderInput={(params) => (
                <TextField {...params} label="Search Platform" />
              )}
            />
          </Grid>
        </Grid>
        {/* <Button onClick={() => reset()}>Reset</Button> */}
        <Button type="submit" variant="contained" sx={{ mt: 2 }}>
          Submit
        </Button>
      </form>
    </Box>
  );
}

export default AddGameForm;
