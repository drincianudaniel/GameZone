import React from "react";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import moment from "moment";
import MoreMenu from "../Menus/MoreMenu";
import { convertUTCDateToLocalDate } from "../../utils/TimeConverting";
import { Link } from "react-router-dom";
import { Box, Typography } from "@mui/material";
import { useUser } from "../../hooks/useUser";
import ReviewService from "../../api/ReviewService";
import StarOutlinedIcon from "@mui/icons-material/StarOutlined";
import { useConfirm } from "material-ui-confirm";

function Review(props) {
  const { user } = useUser();
  const confirm = useConfirm();

  const handleDelete = async () => {
    confirm({ description: "This will permanently delete the review." }).then(
      () => {
        ReviewService.deleteReview(props.review.id, user.Id)
          .then((response) => {
            props.getReviews();
            props.getGame();
          })
          .catch((err) => console.log(err));
      }
    );
  };

  return (
    <Box>
      <Grid container wrap="nowrap" spacing={2}>
        <Grid item>
          <Avatar alt="Remy Sharp" src={props.review.userProfileImage} />
        </Grid>
        <Grid justifyContent="left" item xs zeroMinWidth>
          <Box
            sx={{
              display: "flex",
              justifyContent: "space-between",
              alignItems: "center",
            }}
          >
            <Box
              sx={{
                display: "flex",
                alignItems: {
                  lg: "center",
                  sm: "center",
                  md: "center",
                  xs: "left",
                },
                flexDirection: {
                  xs: "column",
                  sm: "row",
                  md: "row",
                  lg: "row",
                },
              }}
            >
              <Link
                style={{ textDecoration: "none", color: "inherit" }}
                to={`/profile/${props.review.userName}/reviews`}
              >
                <Typography
                  sx={{
                    margin: 0,
                    textAlign: "left",
                    fontWeight: "bold",
                    cursor: "pointer",
                    "&:hover": {
                      color: "primary.main",
                    },
                  }}
                >
                  {props.review.userName}
                </Typography>
              </Link>
              <Typography
                sx={{ fontSize: 15, textAlign: "left", color: "gray", ml: 1 }}
              >
                {moment(
                  convertUTCDateToLocalDate(new Date(props.review.createdAt))
                ).fromNow()}
              </Typography>
            </Box>
            <Box
              sx={{
                height: "100%",
                display: "flex",
                alignItems: "center",
              }}
            >
              <Typography sx={{ margin: 0, fontWeight: "bold" }}>
                {props.review.rating}/10
              </Typography>
              <StarOutlinedIcon
                stroke="orange"
                strokeWidth={1}
                sx={{ color: "#ffea00", marginLeft: 0.5, fontSize: 25 }}
              ></StarOutlinedIcon>
            </Box>
          </Box>
          <Typography sx={{ textAlign: "left", mt: 1 }}>
            {props.review.content}
          </Typography>
        </Grid>
        <Grid>
          {(user.UserName === props.review.userName || user.IsAdmin) && (
            <MoreMenu handleDelete={handleDelete} />
          )}
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </Box>
  );
}

export default Review;
