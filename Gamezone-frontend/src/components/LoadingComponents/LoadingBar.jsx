import LoadingBar from "react-top-loading-bar";

export default function LoadingBarComponent(props) {
  const barColor = "#2998ff";

  return (
    <LoadingBar
      color={barColor}
      progress={props.progress}
      onLoaderFinished={() => props.setProgress(0)}
    />
  );
}
