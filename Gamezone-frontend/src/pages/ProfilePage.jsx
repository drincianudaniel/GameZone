import { Container, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import UserService from "../api/UserService";
import FormDialog from "../components/Dialogs/FormDialog";
import ChangePasswordForm from "../components/Forms/ChangePasswordForm";
import EditUserProfileImageForm from "../components/Forms/EditForms/EditUserProfileImageForm";
import Header from "../components/Header";
import ProfileMoreMenu from "../components/Menus/ProfileMoreMenu";
import UserTabbedPanel from "../components/TabbedPanels/UserTabbedPanel";
import { useUser } from "../hooks/useUser";

function ProfilePage() {
  const [profileUser, setProfileUser] = useState([]);
  const { user } = useUser();
  const params = useParams();

  //modals
  const [openChangePassword, setOpenChangePassword] = useState(false);
  const [openChangeImage, setOpenChangeImage] = useState(false);

  const handleOpenChangeImage = () => {
    setOpenChangeImage(true);
  };

  const handleOpenChangePassword = () => {
    setOpenChangePassword(true);
  };

  useEffect(() => {
    getUser();
  }, [params]);

  const getUser = () => {
    UserService.GetUserByUsername(params.username).then((res) => {
      setProfileUser(res.data);
      console.log(res.data);
    });
  };

  return (
    <>
      <Header />
      <Container maxWidth="lg">
        <Grid container spacing={2} sx={{ mt: 2 }}>
          <Grid
            item
            xs={12}
            sm={12}
            sx={{
              borderBottom: 1,
              display: "flex",
              justifyContent: "space-between",
              alignItems: "center",
            }}
          >
            <Typography variant="h4">
              {" "}
              {profileUser.userName}'s Profile
            </Typography>
            {profileUser.userName === user.UserName && (
              <ProfileMoreMenu
                handlePassword={handleOpenChangePassword}
                handlePicture={handleOpenChangeImage}
              ></ProfileMoreMenu>
            )}
          </Grid>
          <Grid
            item
            xs={12}
            md={3}
            sx={{ borderRight: { lg: 1 }, borderColor: "grey.500" }}
          >
            <Grid item xs={12} md={12} lg={12} justify="center">
              <Box
                sx={{
                  "&:hover": {
                    opacity: "0.95",
                  },
                }}
                component="img"
                alt={profileUser.userName}
                className="gameImg"
                src={profileUser.profileImageSrc}
              />
            </Grid>
          </Grid>
          <Grid item xs={12} sm={12} md={12} lg={9} justify="center">
            <UserTabbedPanel profileUser={profileUser}></UserTabbedPanel>
          </Grid>
        </Grid>
        <FormDialog
          setOpen={setOpenChangePassword}
          open={openChangePassword}
          handleClickOpen={handleOpenChangePassword}
          form={ChangePasswordForm}
        />
        <FormDialog
          setOpen={setOpenChangeImage}
          open={openChangeImage}
          handleClickOpen={handleOpenChangeImage}
          form={EditUserProfileImageForm}
          imageSrc={profileUser.profileImageSrc}
          getUser={getUser}
        />
      </Container>
    </>
  );
}

export default ProfilePage;
