import { useState } from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import axios from "axios";
import Grid from "@mui/material/Grid";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDateFns } from "@mui/x-date-pickers/AdapterDateFns";
import MultipleSelectChip from "../MultipleSelectChip";
import { Box } from "@mui/material";
import { useNavigate } from "react-router";

function AddGameForm() {
  const [date, setDate] = useState(new Date("2018-01-01T00:00:00.000Z"));
  const [selectedDevelopers, setSelectedDevelopers] = useState([]);
  const [selectedGenres, setSelectedGenres] = useState([]);
  const [selectedPlatforms, setSelectedPlatforms] = useState([]);
  const history = useNavigate();

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

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    console.log(data);

    const dataToPost = {
      name: data.Name,
      releaseDate: date,
      imageSrc: data.imgSrc,
      gameDetails: data.Details,
      developerList: selectedDevelopers.map((e) => e.id),
      genreList: selectedGenres.map((e) => e.id),
      platformList: selectedPlatforms.map((e) => e.id),
    };

    axios
      .post(`${process.env.REACT_APP_SERVERIP}/games`, dataToPost)
      .then((response) => {
        reset();
        history(`/game/${response.data.id}`);
      })
      .catch((err) => console.log(err));
  };

  return (
    <Box
      sx={{ width: "100%" }}
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
              sx={{ marginBottom: 1 }}
              label="Image source"
              name="imgSrc"
              id="fullWidth outlined-multiline-static"
              {...register("imgSrc", {
                required: { value: true, message: "Image link is required" },
                pattern: {
                  value:
                    /[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)?/gi,
                  message: "Enter a valid link",
                },
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
            <MultipleSelectChip
              name="Developer"
              getData={getDevelopers}
              handleChange={handleChangeDevelopers}
              valueName={selectedDevelopers}
            />
          </Grid>

          <Grid item xs={12} md={12}>
            <MultipleSelectChip
              name="Genre"
              getData={getGenres}
              handleChange={handleChangeGenres}
              valueName={selectedGenres}
            />
          </Grid>

          <Grid item xs={12} md={12}>
            <MultipleSelectChip
              name="Platform"
              getData={getPlatforms}
              handleChange={handleChangePlatforms}
              valueName={selectedPlatforms}
            />
          </Grid>
        </Grid>
        <Button onClick={() => reset()}>Reset</Button>
        <Button type="submit" variant="contained">
          Submit
        </Button>
      </form>
    </Box>
  );
}

export default AddGameForm;
