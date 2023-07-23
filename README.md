# :pill: CryptoSoft

CryptoSoft is a software that offers file encryption and decryption using the **XOR byte-per-byte** technique.

## How to Use
```
CryptoSoft.exe source "source_file_path" destination "destination_file_path"
```
### Important Information

-   To ensure secure encryption, please follow these steps:
  - Place the crypto key in a `cryptoKey.txt` file.
  - Save the `cryptoKey.txt` file in the config folder located within the **CryptoSoft.exe directory**.
  - The crypto key must be a **minimum of 64 bytes long**.

## Return Codes

-   `-1`: The `source` argument is missing.
-   `-2`: The `destination` argument is missing.
-   `-3`: The crypto key is less than the required minimum of 64 bytes.
-   `-4`: Encryption or decryption failed, possibly due to incorrect file paths.
-   `<0`: The returned value represents the encryption time of the file in milliseconds.

## Changelog

`2.0`
  - Now supports encryption and decryption of large files (greater than 2 GB).
  - Improved security with the placement of crypto key in the config folder.

`1.0`
  - Initial release with support for file encryption and decryption of files below 2 GB in size.
