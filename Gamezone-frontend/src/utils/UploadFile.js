import { BlobServiceClient, ContainerClient } from "@azure/storage-blob";

export async function uploadFile(image, id) {

  let storageAccountName = "gamezone";
  let sasToken = process.env.REACT_APP_SASTOKEN;
  const blobService = new BlobServiceClient(
    `https://${storageAccountName}.blob.core.windows.net/?${sasToken}`
  );
  const containerClient = blobService.getContainerClient("files");

  const blobClient = containerClient.getBlockBlobClient(`${image.name}${id}`);

  const options = { blobHTTPHeaders: { blobContentType: image.type } };

  await blobClient.uploadBrowserData(image, options);
}
