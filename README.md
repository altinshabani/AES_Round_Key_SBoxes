**AES(Advanced Encryption Standard) is a block cipher.**
The key size can be 128/192/256 bits.
Encrypts data in blocks of 128 bits each.

AES performs operations on bytes of data rather than in bits.
Since the block size is 128 bits, the cipher processes 128 bits (or 16 bytes) of the input data at a time.

The number of rounds depends on the key length as follows :
128 bit key – 10 rounds
192 bit key – 12 rounds
256 bit key – 14 rounds

Creation of Round keys :
A Key Schedule algorithm is used to calculate all the round keys from the key. So the initial key is used to create many different round keys which will be used in the corresponding round of the encryption.
![image](https://user-images.githubusercontent.com/119792193/205502478-8fec066e-e501-4683-b57d-654a87e3d050.png)

**Encryption :**
AES considers each block as a 16 byte (4 byte x 4 byte = 128 ) grid in a column major arrangement.

[ b0 | b4 | b8 | b12 |
| b1 | b5 | b9 | b13 |
| b2 | b6 | b10| b14 |
| b3 | b7 | b11| b15 ]

Each round comprises of 4 steps :
SubBytes
ShiftRows
MixColumns
Add Round Key
The last round doesn’t have the MixColumns round.

The SubBytes does the substitution and ShiftRows and MixColumns performs the permutation in the algorithm.

SubBytes  :
This step implements the substitution.In this step each byte is substituted by another byte. 
Its performed using a lookup table also called the S-box. 
This substitution is done in a way that a byte is never substituted by itself and also not substituted by another byte which is a compliment of the current byte. 
The result of this step is a 16 byte (4 x 4 ) matrix like before.

ShiftRows :
This step is just as it sounds. Each row is shifted a particular number of times.

The first row is not shifted
The second row is shifted once to the left.
The third row is shifted twice to the left.
The fourth row is shifted thrice to the left.
(A left circular shift is performed.)

[ b0  | b1  | b2  | b3  ]         [ b0  | b1  | b2  | b3  ]
| b4  | b5  | b6  | b7  |    ->   | b5  | b6  | b7  | b4  |
| b8  | b9  | b10 | b11 |         | b10 | b11 | b8  | b9  |
[ b12 | b13 | b14 | b15 ]         [ b15 | b12 | b13 | b14 ]

MixColumns :
This step is basically a matrix multiplication. Each column is multiplied with a specific matrix and thus the position of each byte in the column is changed as a result.
This step is skipped in the last round.

[ c0 ]         [ 2  3  1  1 ]  [ b0 ]
| c1 |  =      | 1  2  3  1 |     | b1 |
| c2 |      | 1  1  2  3 |     | b2 |
[ c3 ]      [ 3  1  1  2 ]     [ b3 ]

Add Round Keys :
Now the resultant output of the previous stage is XOR-ed with the corresponding round key. Here, the 16 bytes is not considered as a grid but just as 128 bits of data.
![image](https://user-images.githubusercontent.com/119792193/205502562-ad40fede-3c38-4f89-b251-ddcff90eabe8.png)

After all these rounds 128 bits of encrypted data is given back as output. This process is repeated until all the data to be encrypted undergoes this process.
**Decryption :**
The stages in the rounds can be easily undone as these stages have an opposite to it which when performed reverts the changes.Each 128 blocks goes through the 10,12 or 14 rounds depending on the key size.

The stages of each round in decryption is as follows :
Add round key
Inverse MixColumns
ShiftRows
Inverse SubByte
The decryption process is the encryption process done in reverse so i will explain the steps with notable differences.

Inverse MixColumns :
 This step is similar to the MixColumns step in encryption, but differs in the matrix used to carry out the operation.

[ b0 ]         [ 14  11  13  9  ]  [ c0 ]
| b1 |  =      | 9   14  11  13 |     | c1 |
| b2 |      | 13  9   14  11 |     | c2 |
[ b3 ]         [ 11  13  9   14 ]     [ c3 ]
Inverse SubBytes :
Inverse S-box is used as a lookup table and using which the bytes are substituted during decryption.

