# Presentation

CryptoSoft is a software that can encrypt or decrypt any file using XOR byte per byte technique.

# Syntax

Command line to use : CryptoSoft.exe source "sourceFile_path"  destination "destinationFile_path"

Example : CryptoSoft.exe source "C:\Users\simon\3D Objects\TestCryptoSoft\TestCryptoSoft.txt" destination "C:\Users\simon\3D Objects\Destination TestCryptoSoft\TestCryptoSoft.txt"

# Important Informations

The Crypto Key must be placed in a txt file named "cryptoKey.txt", which is placed in a config folder, placed in the CryptoSoft.exe directory.

The Crypto Key must be 64 bytes long minimum.

# Return code of the exe

-1 : The first argument "source" is not present.

-2 : The second argument "destination" is not present.

-3 : The Crypto key is not the minimum 64 bytes long.

-4 : Encryption or decryption failed, error could be that the paths are wrong.

<0 : The value returned is the encryption time of the file in milliseconds.

# Changelog

2.0 :
- You can now encrypt and decrypt large files (more than 2 gb ).
- Crypto key is now placed in a config folder.

1.0 : 
- You can encrypt and decrypt any files below 2gb size.