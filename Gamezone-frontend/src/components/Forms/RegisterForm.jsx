import React, { useRef, useState } from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import {
  Box,
  FormControl,
  FormHelperText,
  Grid,
  IconButton,
  InputAdornment,
  InputLabel,
  OutlinedInput,
  Paper,
} from "@mui/material";
import UserService from "../../api/UserService";
import { Visibility, VisibilityOff } from "@mui/icons-material";
import { toast } from "react-toastify";
import { useNavigate } from "react-router";

function RegisterForm() {
  const [showPassword, setShowPassword] = useState(false);
  const history = useNavigate();
  const {
    register,
    handleSubmit,
    formState: { errors },
    watch,
  } = useForm();

  //password confirm
  const password = useRef({});
  password.current = watch("Password", "");

  const handleClickShowPassword = () => {
    setShowPassword(!showPassword);
  };

  const handleMouseDownPassword = (event) => {
    event.preventDefault();
  };

  const submit = (data) => {
    console.log(data);

    const dataToPost = {
      firstName: data.FirstName,
      lastName: data.LastName,
      userName: data.Username,
      email: data.Email,
      password: data.Password,
      profileImageSrc:
        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRNDgyaDCaoDZJx8N9BBE6eXm5uXuObd6FPeg&usqp=CAU",
    };

    UserService.Register(dataToPost)
      .then((res) => {
        console.log(res);
        history("/login");
        toast.success("Registered Successfully");
      })
      .catch((err) => {
        console.log(err);
        toast.error(err.response.data);
      });
  };

  return (
    <Box
      sx={{ width: "100%", height: "100%" }}
      display="flex"
      justifyContent="center"
      alignItems="center"
    >
      <Paper elevation={24} sx={{ padding: 1 }}>
        <form noValidate autoComplete="off" onSubmit={handleSubmit(submit)}>
          <Grid container spacing={2} sx={{ mt: 1 }}>
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
                  pattern: {
                    value: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/i,
                    message: "Valid email required",
                  },
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
            <Grid item sm={12} xs={12} sx={{ width: "100%" }}>
              <FormControl sx={{ width: "100%" }}>
                <InputLabel htmlFor="component-simple">Password *</InputLabel>
                <OutlinedInput
                  id="component-simple"
                  sx={{ width: "100%" }}
                  required
                  label="Password"
                  name="Password"
                  type={showPassword ? "text" : "password"}
                  endAdornment={
                    <InputAdornment position="end">
                      <IconButton
                        aria-label="toggle password visibility"
                        onClick={handleClickShowPassword}
                        onMouseDown={handleMouseDownPassword}
                        edge="end"
                      >
                        {showPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  }
                  {...register("Password", {
                    required: { value: true, message: "Password is required" },
                    pattern: {
                      value:
                        /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/i,
                      message:
                        "Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character",
                    },
                  })}
                  error={!!errors.Password}
                  helperText={errors.Password?.message}
                />
                {!!errors.Password && (
                  <FormHelperText error id="accountId-error">
                    {errors.Password?.message}
                  </FormHelperText>
                )}
              </FormControl>
            </Grid>
            <Grid item sm={12} xs={12} sx={{ width: "100%" }}>
              <FormControl sx={{ width: "100%" }}>
                <InputLabel htmlFor="component-simple">
                  Repeat Password *
                </InputLabel>
                <OutlinedInput
                  id="component-simple"
                  sx={{ width: "100%" }}
                  required
                  label="Repeat Password"
                  name="Password_repeat"
                  type={showPassword ? "text" : "password"}
                  endAdornment={
                    <InputAdornment position="end">
                      <IconButton
                        aria-label="toggle password visibility"
                        onClick={handleClickShowPassword}
                        onMouseDown={handleMouseDownPassword}
                        edge="end"
                      >
                        {showPassword ? <VisibilityOff /> : <Visibility />}
                      </IconButton>
                    </InputAdornment>
                  }
                  {...register("Password_repeat", {
                    validate: (value) =>
                      value === password.current ||
                      "The passwords do not match",
                  })}
                  error={!!errors.Password_repeat}
                  helperText={errors.Password_repeat?.message}
                />
                {!!errors.Password_repeat && (
                  <FormHelperText error id="accountId-error">
                    {errors.Password_repeat?.message}
                  </FormHelperText>
                )}
              </FormControl>
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
