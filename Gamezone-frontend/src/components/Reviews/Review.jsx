import React from "react";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import moment from "moment";
import IconButton from "@mui/material/IconButton";
import ClearIcon from "@mui/icons-material/Clear";
import axios from "axios";

const imgLink =
  "https://images.pexels.com/photos/1681010/pexels-photo-1681010.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260";

function convertUTCDateToLocalDate(date) {
  var newDate = new Date(date.getTime() + date.getTimezoneOffset() * 60 * 1000);

  var offset = date.getTimezoneOffset() / 60;
  var hours = date.getHours();

  newDate.setHours(hours - offset);

  return newDate;
}

function Review(props) {
  const deleteReview = async () => {
    await axios
      .delete(`${process.env.REACT_APP_SERVERIP}/reviews/${props.comment.id}`)
      .then((response) => {
        props.getReviews();
      })
      .catch((err) => console.log(err));
  };

  return (
    <div style={{ padding: 14 }} className="App">
      <Grid container wrap="nowrap" spacing={2}>
        <Grid item>
          <Avatar alt="Remy Sharp" src={imgLink} />
        </Grid>
        <Grid justifyContent="left" item xs zeroMinWidth>
        <h4 style={{ margin: 0, textAlign: "left" }}>
          {props.comment.rating}/10
          </h4>
          <h4 style={{ margin: 0, textAlign: "left" }}>
            {props.comment.username}
          </h4>
          <p style={{ textAlign: "left" }}>{props.comment.content}</p>
          <p style={{ textAlign: "left", color: "gray" }}>
            {moment(
              convertUTCDateToLocalDate(new Date(props.comment.createdAt))
            ).fromNow()}
          </p>
        </Grid>
        <Grid>
          <IconButton aria-label="Delete" onClick={deleteReview}>
            <ClearIcon></ClearIcon>
          </IconButton>
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </div>
  );
}

export default Review;
