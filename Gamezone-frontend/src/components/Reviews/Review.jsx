import React from "react";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import moment from "moment";
import axios from "axios";
import MoreMenu from "../Menus/MoreMenu";
import { convertUTCDateToLocalDate } from "../../utils/TimeConverting";
import { Link } from "react-router-dom";
import { Typography } from "@mui/material";
import { useUser } from "../../hooks/useUser";
import ReviewService from "../../api/ReviewService";

function Review(props) {
  const {user} = useUser()

  const handleDelete = async () => {
      ReviewService.deleteReview(props.review.id, user.Id)
      .then((response) => {
        props.getReviews();
      })
      .catch((err) => console.log(err));
  };

  return (
    <div style={{ padding: 14 }} className="App">
      <Grid container wrap="nowrap" spacing={2}>
        <Grid item>
          <Avatar alt="Remy Sharp" src={props.review.userProfileImage} />
        </Grid>
        <Grid justifyContent="left" item xs zeroMinWidth>
          <h4 style={{ margin: 0, textAlign: "left" }}>
            {props.review.rating}/10
          </h4>
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
          <p style={{ textAlign: "left" }}>{props.review.content}</p>
          <p style={{ textAlign: "left", color: "gray" }}>
            {moment(
              convertUTCDateToLocalDate(new Date(props.review.createdAt))
            ).fromNow()}
          </p>
        </Grid>
        <Grid>
          {(user.UserName === props.review.userName || user.IsAdmin) && (
            <MoreMenu handleDelete={handleDelete} />
          )}
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </div>
  );
}

export default Review;
