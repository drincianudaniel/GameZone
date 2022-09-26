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

function Review(props) {
  const handleDelete = async () => {
    await axios
      .delete(`${process.env.REACT_APP_SERVERIP}/reviews/${props.review.id}`)
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
            to={`/profile/${props.review.userName}`}
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
          <MoreMenu handleDelete={handleDelete} />
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </div>
  );
}

export default Review;
