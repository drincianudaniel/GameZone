import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Header from "../components/Header";
import Typography from "@mui/material/Typography";
import "./css/GameDetailsPage.css";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import moment from "moment";
import DetailsTabbedPanel from "../components/TabbedPanels/DetailsTabbedPannel";
import { Container, Divider, IconButton } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import useMediaQuery from "@mui/material/useMediaQuery";
import SpinningLoading from "../components/LoadingComponents/SpinningLoading";
import GameService from "../api/GameService";
import FormDialog from "../components/Dialogs/FormDialog";
import EditGameDetailsForm from "../components/Forms/EditForms/EditGameDetailsForm";
import ImageModal from "../components/Modals/ImageModal";
import { useUser } from "../hooks/useUser";
import StarOutlinedIcon from "@mui/icons-material/StarOutlined";
import AddIcon from "@mui/icons-material/Add";
import GameChip from "../components/Chips/GameChip";
import GameAddPopover from "../components/Popovers/GameAddPopover";
import EditGameNameForm from "../components/Forms/EditForms/EditGameNameForm";
import GameMoreMenu from "../components/Menus/GameMoreMenu";
import EditGameDateForm from "../components/Forms/EditForms/EditGameDateForm";
import EditGameImageForm from "../components/Forms/EditForms/EditGamePictureForm";
import FavoriteButton from "../components/Buttons/FavoriteButton";
import { useConfirm } from "material-ui-confirm";

function GameDetailsPage() {
  const [game, setGame] = useState([]);
  const [developers, setDevelopers] = useState([]);
  const [genres, setGenres] = useState([]);
  const [platforms, setPlatforms] = useState([]);

  const [isLoading, setIsLoading] = useState(false);
  const params = useParams();
  const theme = useTheme();
  const history = useNavigate();
  const confirm = useConfirm();

  //modals
  const [open, setOpen] = useState(false);
  const [openImageModal, setOpenImageModal] = useState(false);
  const [openName, setOpenName] = useState(false);
  const [openDate, setOpenDate] = useState(false);
  const [openImage, setOpenImage] = useState(false);

  const handleClickOpenImage = () => {
    setOpenImage(true);
  };

  const handleClickOpenDate = () => {
    setOpenDate(true);
  };

  const handleClickOpenName = () => {
    setOpenName(true);
  };

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleImage = () => {
    setOpenImageModal(true);
  };

  //popover
  const [anchorElGenres, setAnchorElGenres] = useState(null);
  const [anchorElDevelopers, setAnchorElDevelopers] = useState(null);
  const [anchorElPlatforms, setAnchorElPlatforms] = useState(null);

  const handleClickGenrePopover = (event) => {
    setAnchorElGenres(event.currentTarget);
  };

  const handleClickDeveloperPopover = (event) => {
    setAnchorElDevelopers(event.currentTarget);
  };

  const handleClickPlatformPopover = (event) => {
    setAnchorElPlatforms(event.currentTarget);
  };

  //user
  const { user } = useUser();
  useEffect(() => {
    getGame();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [params.id]);

  const getGame = async () => {
    setIsLoading(true);
    GameService.getGame(params.id)
      .then((res) => {
        setGame(res.data);
        setDevelopers(res.data.developers);
        setGenres(res.data.genres);
        setPlatforms(res.data.platforms);
        setIsLoading(false);
      })
      .catch((err) => {
        setIsLoading(false);
      });
  };

  const getDevelopers = async () => {
    GameService.getGame(params.id).then((res) => {
      setDevelopers(res.data.developers);
    });
  };

  const getGenres = async () => {
    GameService.getGame(params.id).then((res) => {
      setGenres(res.data.genres);
    });
  };

  const getPlatforms = async () => {
    GameService.getGame(params.id).then((res) => {
      setPlatforms(res.data.platforms);
    });
  };

  const handleDelete = () => {
    confirm({ description: "This will permanently delete the game." }).then(
      () => {
        GameService.deleteGame(params.id).then((res) => {
          history(`/games`);
        });
      }
    );
  };

  return (
    <div>
      <Header />
      <Container
        maxWidth="lg"
        disableGutters={useMediaQuery(theme.breakpoints.only("xs"))}
      >
        <Box sx={{ flexGrow: 1, padding: 5 }}>
          {isLoading ? (
            <SpinningLoading />
          ) : (
            <Grid container spacing={2}>
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
                <Typography variant="h4">{game.name}</Typography>
                <Box
                  sx={{
                    display: "flex",
                    justifyContent: "space-between",
                    alignItems: "center",
                  }}
                >
                  <FavoriteButton
                    id={game.id}
                    isFavorite={game.isFavorite}
                  ></FavoriteButton>
                  {user.IsAdmin && (
                    <GameMoreMenu
                      handleDelete={handleDelete}
                      handleName={handleClickOpenName}
                      handleDate={handleClickOpenDate}
                      handleImage={handleClickOpenImage}
                    />
                  )}
                </Box>
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
                    alt={game.name}
                    className="gameImg"
                    src={game.imageSrc}
                    onClick={(e) => handleImage()}
                  />
                  <Typography>
                    Release date:{" "}
                    {moment(game.releaseDate).format("MMMM Do YYYY")}
                  </Typography>
                  <Divider />
                  <Typography>Developers:</Typography>
                  {developers.length > 0 ? (
                    <>
                      {developers.map((developer) => (
                        <GameChip
                          key={developer.id}
                          data={developer}
                          type="developer"
                          getGame={getDevelopers}
                        />
                      ))}
                      {user.IsAdmin && (
                        <>
                          <IconButton onClick={handleClickDeveloperPopover}>
                            <AddIcon fontSize="small"></AddIcon>
                          </IconButton>
                          <GameAddPopover
                            presentData={developers}
                            getGame={getDevelopers}
                            type="developer"
                            handleClick={handleClickDeveloperPopover}
                            anchorEl={anchorElDevelopers}
                            setAnchorEl={setAnchorElDevelopers}
                          />
                        </>
                      )}
                    </>
                  ) : (
                    <>
                      <Typography>No Developers</Typography>
                      {user.IsAdmin && (
                        <>
                          <IconButton onClick={handleClickDeveloperPopover}>
                            <AddIcon fontSize="small"></AddIcon>
                          </IconButton>
                          <GameAddPopover
                            presentData={developers}
                            getGame={getDevelopers}
                            type="developer"
                            handleClick={handleClickDeveloperPopover}
                            anchorEl={anchorElDevelopers}
                            setAnchorEl={setAnchorElDevelopers}
                          />
                        </>
                      )}
                    </>
                  )}
                  <Typography>Genres:</Typography>
                  {genres.length > 0 ? (
                    <>
                      {genres.map((genre) => (
                        <GameChip
                          key={genre.id}
                          data={genre}
                          type="genre"
                          getGame={getGenres}
                        />
                      ))}

                      {user.IsAdmin && (
                        <>
                          <IconButton onClick={handleClickGenrePopover}>
                            <AddIcon fontSize="small"></AddIcon>
                          </IconButton>
                          <GameAddPopover
                            presentData={genres}
                            getGame={getGenres}
                            type="genre"
                            handleClick={handleClickGenrePopover}
                            anchorEl={anchorElGenres}
                            setAnchorEl={setAnchorElGenres}
                          />
                        </>
                      )}
                    </>
                  ) : (
                    <>
                      <Typography>No Genres</Typography>
                      {user.IsAdmin && (
                        <>
                          <IconButton onClick={handleClickGenrePopover}>
                            <AddIcon fontSize="small"></AddIcon>
                          </IconButton>
                          <GameAddPopover
                            presentData={genres}
                            getGame={getGenres}
                            type="genre"
                            handleClick={handleClickGenrePopover}
                            anchorEl={anchorElGenres}
                            setAnchorEl={setAnchorElGenres}
                          />
                        </>
                      )}
                    </>
                  )}
                  <Typography>Platforms:</Typography>
                  {platforms && platforms.length > 0 ? (
                    <>
                      {platforms.map((platform) => (
                        <GameChip
                          key={platform.id}
                          data={platform}
                          type="platform"
                          getGame={getPlatforms}
                        />
                      ))}
                      {user.IsAdmin && (
                        <>
                          <IconButton onClick={handleClickPlatformPopover}>
                            <AddIcon fontSize="small"></AddIcon>
                          </IconButton>
                          <GameAddPopover
                            presentData={platforms}
                            type="platform"
                            getGame={getPlatforms}
                            handleClick={handleClickPlatformPopover}
                            anchorEl={anchorElPlatforms}
                            setAnchorEl={setAnchorElPlatforms}
                          />
                        </>
                      )}
                    </>
                  ) : (
                    <>
                      <Typography>No Platforms</Typography>
                      {user.IsAdmin && (
                        <>
                          <IconButton onClick={handleClickPlatformPopover}>
                            <AddIcon fontSize="small"></AddIcon>
                          </IconButton>
                          <GameAddPopover
                            presentData={platforms}
                            type="platform"
                            getGame={getPlatforms}
                            handleClick={handleClickPlatformPopover}
                            anchorEl={anchorElPlatforms}
                            setAnchorEl={setAnchorElPlatforms}
                          />
                        </>
                      )}
                    </>
                  )}
                </Grid>
              </Grid>
              <Grid item xs={12} sm={12} md={12} lg={9} justify="center">
                <Box sx={{ flexGrow: 1 }} className="detailsBox">
                  <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={12}>
                      <Box
                        sx={{
                          height: "100%",
                          display: "flex",
                          alignItems: "center",
                        }}
                      >
                        <Typography sx={{ fontSize: 30, mr: 1 }}>
                          {Math.round(game.totalRating * 10) / 10}/10
                        </Typography>
                        <StarOutlinedIcon
                          stroke="orange"
                          strokeWidth={1}
                          sx={{
                            color: "#ffea00",
                            mr: 1,
                            fontSize: 25,
                          }}
                        ></StarOutlinedIcon>
                        {user.IsLoggedIn && (
                          <>
                            {" "}
                            {game.review ? (
                              <>
                                <Typography>
                                  (My rating: {game.review.rating}/10)
                                </Typography>
                              </>
                            ) : (
                              // <Typography>(Not Reviewed)</Typography>
                              <></>
                            )}
                          </>
                        )}
                      </Box>
                    </Grid>
                    <Grid item xs={12} md={12} sx={{ borderBottom: 1 }}>
                      <Box sx={{ minHeight: "315px" }} className="details">
                        <Box
                          sx={{
                            display: "flex",
                            justifyContent: "space-between",
                            alignItems: "center",
                          }}
                        >
                          <Typography
                            sx={{ fontWeight: "bold", marginBottom: 0.2 }}
                          >
                            Synopsis:
                          </Typography>
                          {user.IsAdmin && (
                            <Typography
                              onClick={handleClickOpen}
                              sx={{
                                marginBottom: 0.2,
                                cursor: "pointer",
                                "&:hover": {
                                  color: "primary.main",
                                },
                              }}
                            >
                              Edit
                            </Typography>
                          )}
                        </Box>
                        <Divider />
                        <Typography sx={{ mt: 1 }}>
                          {game.gameDetails}
                        </Typography>
                      </Box>
                    </Grid>
                  </Grid>
                  <DetailsTabbedPanel getGame={getGame} />
                </Box>
              </Grid>
            </Grid>
          )}
        </Box>
        {/* Dialogs */}
        <FormDialog
          id={params.id}
          setOpen={setOpen}
          open={open}
          handleClickOpen={handleClickOpen}
          getGame={getGame}
          details={game.gameDetails}
          form={EditGameDetailsForm}
        />
        <FormDialog
          id={params.id}
          setOpen={setOpenName}
          open={openName}
          handleClickOpen={handleClickOpenName}
          getGame={getGame}
          name={game.name}
          form={EditGameNameForm}
        />
        <FormDialog
          id={params.id}
          setOpen={setOpenDate}
          open={openDate}
          handleClickOpen={handleClickOpenDate}
          getGame={getGame}
          date={game.releaseDate}
          form={EditGameDateForm}
        />
        <FormDialog
          id={params.id}
          setOpen={setOpenImage}
          open={openImage}
          handleClickOpen={handleClickOpenImage}
          getGame={getGame}
          imageSrc={game.imageSrc}
          form={EditGameImageForm}
        />
        <ImageModal
          open={openImageModal}
          setOpen={setOpenImageModal}
          image={game.imageSrc}
        />
      </Container>
    </div>
  );
}

export default GameDetailsPage;
