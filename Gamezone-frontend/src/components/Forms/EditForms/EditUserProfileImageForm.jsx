import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Grid } from "@mui/material";
import { v4 as uuidv4 } from "uuid";
import { uploadFile } from "../../../utils/UploadFile";
import UserService from "../../../api/UserService";

function EditUserProfileImageForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    let uniqueId = uuidv4();
    uploadFile(data.ImageSrc[0], uniqueId);

    console.log(data);

    const dataToPost = {
      from: props.imageSrc,
      value: `https://gamezone.blob.core.windows.net/files/${data.ImageSrc[0].name}${uniqueId}`,
    };

    UserService.updateUserProfileImage(dataToPost).then((res) => {
      props.getUser();
      props.handleClose();
    });
  };

  useEffect(() => {
    console.log(props);
  });
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
              type="file"
              sx={{ marginBottom: 1, width: { md: "500px", sx: "400px" } }}
              name="ImageSrc"
              id="fullWidth outlined-multiline-static"
              {...register("ImageSrc", {
                required: { value: true, message: "ImageSrc is required" },
              })}
              error={!!errors.ImageSrc}
              helperText={errors.ImageSrc?.message}
            />
          </Grid>
        </Grid>
        <Button type="submit" variant="contained">
          Submit
        </Button>
      </form>
    </Box>
  );
}

export default EditUserProfileImageForm;
