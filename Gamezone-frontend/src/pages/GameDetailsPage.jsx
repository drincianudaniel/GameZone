import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Header from "../components/Header";
import Typography from "@mui/material/Typography";
import "./css/GameDetailsPage.css";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Chip from "@mui/material/Chip";
import moment from "moment";
import DetailsTabbedPanel from "../components/TabbedPanels/DetailsTabbedPannel";
import { Container, Divider, IconButton } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import useMediaQuery from "@mui/material/useMediaQuery";
import SpinningLoading from "../components/LoadingComponents/SpinningLoading";
import GameService from "../api/GameService";
import MoreMenu from "../components/Menus/MoreMenu";
import FormDialog from "../components/Dialogs/FormDialog";
import EditGameDetailsForm from "../components/Forms/EditForms/EditGameDetailsForm";
import ImageModal from "../components/Modals/ImageModal";
import { useUser } from "../hooks/useUser";
import StarOutlinedIcon from "@mui/icons-material/StarOutlined";
import AddIcon from "@mui/icons-material/Add";
import GameChip from "../components/Chips/GameChip";

function GameDetailsPage() {
  const [game, setGame] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const params = useParams();
  const theme = useTheme();
  const history = useNavigate();

  const [open, setOpen] = useState(false);
  const [openImageModal, setOpenImageModal] = useState(false);

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
        setIsLoading(false);
      })
      .catch((err) => {
        setIsLoading(false);
      });
  };

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleImage = () => {
    setOpenImageModal(true);
    console.log("click");
  };

  const handleDelete = () => {
    GameService.deleteGame(params.id).then((res) => {
      history(`/games`);
    });
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
                {user.IsAdmin && <MoreMenu handleDelete={handleDelete} />}
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
                  {game.developers && game.developers.length > 0 ? (
                    <>
                      {game.developers.map((developer) => (
                        <GameChip
                          data={developer}
                          type="developer"
                          getGame={getGame}
                        />
                      ))}
                      {user.IsAdmin && (
                        <IconButton>
                          <AddIcon fontSize="small"></AddIcon>
                        </IconButton>
                      )}
                    </>
                  ) : (
                    <>
                      <Typography>No Developers</Typography>
                      {user.IsAdmin && (
                        <IconButton>
                          <AddIcon fontSize="small"></AddIcon>
                        </IconButton>
                      )}
                    </>
                  )}
                  <Typography>Genres:</Typography>
                  {game.genres && game.genres.length > 0 ? (
                    <>
                      {game.genres.map((genre) => (
                        <GameChip data={genre} type="genre" getGame={getGame} />
                      ))}

                      {user.IsAdmin && (
                        <IconButton>
                          <AddIcon fontSize="small"></AddIcon>
                        </IconButton>
                      )}
                    </>
                  ) : (
                    <>
                      <Typography>No Genres</Typography>
                      {user.IsAdmin && (
                        <IconButton>
                          <AddIcon fontSize="small"></AddIcon>
                        </IconButton>
                      )}
                    </>
                  )}
                  <Typography>Platforms:</Typography>
                  {game.platforms && game.platforms.length > 0 ? (
                    <>
                      {game.platforms.map((platform) => (
                        <GameChip
                          data={platform}
                          type="platform"
                          getGame={getGame}
                        />
                      ))}
                      {user.IsAdmin && (
                        <IconButton>
                          <AddIcon fontSize="small"></AddIcon>
                        </IconButton>
                      )}
                    </>
                  ) : (
                    <>
                      <Typography>No Platforms</Typography>
                      {user.IsAdmin && (
                        <IconButton>
                          <AddIcon fontSize="small"></AddIcon>
                        </IconButton>
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
                          {game.totalRating}/10
                        </Typography>
                        <StarOutlinedIcon
                          stroke="orange"
                          strokeWidth={1}
                          sx={{
                            color: "#ffea00",
                            marginRight: 1,
                            fontSize: 25,
                          }}
                        ></StarOutlinedIcon>
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
        <FormDialog
          id={params.id}
          setOpen={setOpen}
          open={open}
          handleClickOpen={handleClickOpen}
          getGame={getGame}
          details={game.gameDetails}
          form={EditGameDetailsForm}
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
