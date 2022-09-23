import React from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Grid, Paper } from "@mui/material";

function RegisterForm() {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    console.log(data);

    // const dataToPost = {
    //   username: data.Name,
    //   password: data.Password,
    // };

    // axios
    //   .post(`${process.env.REACT_APP_SERVERIP}/genres`, dataToPost)
    //   .then((response) => {
    //     console.log(response);
    //     toast.success("Genre Added");
    //     reset();
    //   })
    //   .catch((err) => console.log(err));
  };

  return (
    <Box
      sx={{ width: "100%", height: "100%" }}
      display="flex"
      justifyContent="center"
      alignItems="center"
    >
      <Paper elevation={24} variant="outlined" sx={{ padding: 1 }}>
        <form noValidate autoComplete="off" onSubmit={handleSubmit(submit)}>
          <Grid container spacing = {2}>
            <Grid item sm={6} xs={12}>
              <TextField
                fullWidth
                required
                label="First Name"
                name="FirstName"
                id="fullWidth outlined-multiline-static"
                {...register("FirstName", {
                  required: { value: true, message: "FirstName is required" },
                })}
                error={!!errors.FirstName}
                helperText={errors.FirstName?.message}
              />
            </Grid>
            <Grid item sm={6} xs={12}>
              <TextField
                fullWidth
                required
                label="Last Name"
                name="LastName"
                id="fullWidth outlined-multiline-static"
                {...register("LastName", {
                  required: { value: true, message: "LastName is required" },
                })}
                error={!!errors.LastName}
                helperText={errors.LastName?.message}
              />
            </Grid>
            <Grid item sm={12} xs={12}>
              <TextField
                fullWidth
                required
                label="Email"
                name="Email"
                id="fullWidth outlined-multiline-static"
                {...register("Email", {
                  required: { value: true, message: "Email is required" },
                })}
                error={!!errors.Email}
                helperText={errors.Email?.message}
              />
            </Grid>
            <Grid item sm={12} xs={12}>
              <TextField
                fullWidth
                required
                label="Username"
                name="Username"
                id="fullWidth outlined-multiline-static"
                {...register("Username", {
                  required: { value: true, message: "Username is required" },
                })}
                error={!!errors.Username}
                helperText={errors.Username?.message}
              />
            </Grid>
            <Grid item sm={12} xs={12}>
              <TextField
                fullWidth
                required
                label="Password"
                name="Password"
                id="fullWidth outlined-multiline-static"
                {...register("Password", {
                  required: { value: true, message: "Password is required" },
                })}
                error={!!errors.Password}
                helperText={errors.Password?.message}
              />
            </Grid>
            <Grid item sm={12} xs={12}>
              <Box
                sx={{
                  width: "100%",
                  display: "flex",
                  justifyContent: "center",
                }}
              >
                {" "}
                <Button type="submit" variant="contained">
                  Submit
                </Button>
              </Box>{" "}
            </Grid>
          </Grid>
        </form>
      </Paper>
    </Box>
  );
}

export default RegisterForm;
