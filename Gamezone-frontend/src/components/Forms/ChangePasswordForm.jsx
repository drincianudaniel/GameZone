import React, { useEffect } from "react";
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
import { useState } from "react";
import { useNavigate } from "react-router";
import { toast } from "react-toastify";
import { Visibility, VisibilityOff } from "@mui/icons-material";
import { useUser } from "../../hooks/useUser";

function ChangePasswordForm() {
  const [showPassword, setShowPassword] = useState(false);
  const history = useNavigate();
  const { user, setUser } = useUser();

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const handleClickShowPassword = () => {
    setShowPassword(!showPassword);
  };

  const handleMouseDownPassword = (event) => {
    event.preventDefault();
  };

  const submit = (data) => {
    const dataToPost = {
      oldPassword: data.OldPassword,
      newPassword: data.NewPassword,
    };

    UserService.ChangePassword(dataToPost)
      .then((res) => {
        toast.success(res.data + ". Please Login.");
        history("/login");
        localStorage.clear();
        setUser([]);
      })
      .catch((err) => {
        toast.error(err.response.data);
      });
  };

  return (
    <Box
      sx={{ width: "100%", mt: 1 }}
      display="flex"
      justifyContent="center"
      alignItems="center"
    >
      <form
        noValidate
        autoComplete="off"
        style={{ marginBottom: 20 }}
        onSubmit={handleSubmit(submit)}
      >
        <Grid container spacing={2}>
          <Grid item xs={12} md={12}>
            <TextField
              fullWidth
              required
              sx={{ marginBottom: 1, width: { md: "500px", sx: "400px" } }}
              label="Old Password"
              name="OldPassword"
              type="password"
              id="fullWidth outlined-multiline-static"
              {...register("OldPassword", {
                required: { value: true, message: "OldPassword is required" },
              })}
              error={!!errors.OldPassword}
              helperText={errors.OldPassword?.message}
            />
          </Grid>
          <Grid item sm={12} xs={12}>
            <FormControl sx={{ width: "100%" }}>
              <InputLabel htmlFor="component-simple">New Password *</InputLabel>
              <OutlinedInput
                id="component-simple"
                sx={{ marginBottom: 1, width: { md: "500px", sx: "400px" } }}
                required
                label="New Password"
                name="NewPassword"
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
                {...register("NewPassword", {
                  required: { value: true, message: "NewPassword is required" },
                  pattern: {
                    value:
                      /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/i,
                    message:
                      "Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character",
                  },
                })}
                error={!!errors.NewPassword}
                helperText={errors.NewPassword?.message}
              />
              {!!errors.NewPassword && (
                <FormHelperText error id="accountId-error">
                  {errors.NewPassword?.message}
                </FormHelperText>
              )}
            </FormControl>
          </Grid>
        </Grid>
        <Button type="submit" variant="contained">
          Submit
        </Button>
      </form>
    </Box>
  );
}

export default ChangePasswordForm;
