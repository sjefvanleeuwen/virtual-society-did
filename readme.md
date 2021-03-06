<p align=center>
    <img src="./doc/img/logo.svg" />
</p>
<br/>


# Decentralized Identities (Post-Quantum)

This project contains the model for Decentralized identities using the DID specification. https://www.w3.org/TR/did-core/

## Status

Currently we support the minimal DID specification for a self managed identity. It is not meant for
production.

## Quantum Proof key infrastructure

VirtualSociety follows the open-quantum-safe workgroup and is informed by the NIST Post-Quantum Cryptography Standardization project.

NIST can be found at: https://csrc.nist.gov/Projects/Post-Quantum-Cryptography/Post-Quantum-Cryptography-Standardization

## Supported Algorithms

### Key encapsulation mechanisms

```
    BIKE: BIKE1-L1-CPA, BIKE1-L3-CPA, BIKE1-L1-FO, BIKE1-L3-FO
    Classic McEliece: Classic-McEliece-348864†, Classic-McEliece-348864f†, Classic-McEliece-460896†, Classic-McEliece-460896f†, Classic-McEliece-6688128†, Classic-McEliece-6688128f†, Classic-McEliece-6960119†, Classic-McEliece-6960119f†, Classic-McEliece-8192128†, Classic-McEliece-8192128f†
    FrodoKEM: FrodoKEM-640-AES, FrodoKEM-640-SHAKE, FrodoKEM-976-AES, FrodoKEM-976-SHAKE, FrodoKEM-1344-AES, FrodoKEM-1344-SHAKE
    Kyber: Kyber512, Kyber768, Kyber1024, Kyber512-90s, Kyber768-90s, Kyber1024-90s
    LEDAcrypt: LEDAcryptKEM-LT12, LEDAcryptKEM-LT32, LEDAcryptKEM-LT52†
    NewHope: NewHope-512-CCA, NewHope-1024-CCA
    NTRU: NTRU-HPS-2048-509, NTRU-HPS-2048-677, NTRU-HPS-4096-821, NTRU-HRSS-701
    SABER: LightSaber-KEM, Saber-KEM, FireSaber-KEM
    SIKE: SIDH-p434, SIDH-p503, SIDH-p610, SIDH-p751, SIKE-p434, SIKE-p503, SIKE-p610, SIKE-p751, SIDH-p434-compressed, SIDH-p503-compressed, SIDH-p610-compressed, SIDH-p751-compressed, SIKE-p434-compressed, SIKE-p503-compressed, SIKE-p610-compressed, SIKE-p751-compressed
    ThreeBears: BabyBearEphem, BabyBear, MamaBearEphem, MamaBear, PapaBearEphem, PapaBear
```

### Signature Schemes

```
    Dilithium: Dilithium2, Dilithium3, Dilithium4
    Falcon: Falcon-512, Falcon-1024
    MQDSS: MQDSS-31-48, MQDSS-31-64
    Picnic: Picnic-L1-FS, Picnic-L1-UR, Picnic-L3-FS, Picnic-L3-UR, Picnic-L5-FS, Picnic-L5-UR, Picnic2-L1-FS, Picnic2-L3-FS, Picnic2-L5-FS
    qTesla: qTesla-p-I, qTesla-p-III
    Rainbow: Rainbow-Ia-Classic, Rainbow-Ia-Cyclic, Rainbow-Ia-Cyclic-Compressed, Rainbow-IIIc-Classic†, Rainbow-IIIc-Cyclic†, Rainbow-IIIc-Cyclic-Compressed†, Rainbow-Vc-Classic†, Rainbow-Vc-Cyclic†, Rainbow-Vc-Cyclic-Compressed†
    SPHINCS+-Haraka: SPHINCS+-Haraka-128f-robust, SPHINCS+-Haraka-128f-simple, SPHINCS+-Haraka-128s-robust, SPHINCS+-Haraka-128s-simple, SPHINCS+-Haraka-192f-robust, SPHINCS+-Haraka-192f-simple, SPHINCS+-Haraka-192s-robust, SPHINCS+-Haraka-192s-simple, SPHINCS+-Haraka-256f-robust, SPHINCS+-Haraka-256f-simple, SPHINCS+-Haraka-256s-robust, SPHINCS+-Haraka-256s-simple
    SPHINCS+-SHA256: SPHINCS+-SHA256-128f-robust, SPHINCS+-SHA256-128f-simple, SPHINCS+-SHA256-128s-robust, SPHINCS+-SHA256-128s-simple, SPHINCS+-SHA256-192f-robust, SPHINCS+-SHA256-192f-simple, SPHINCS+-SHA256-192s-robust, SPHINCS+-SHA256-192s-simple, SPHINCS+-SHA256-256f-robust, SPHINCS+-SHA256-256f-simple, SPHINCS+-SHA256-256s-robust, SPHINCS+-SHA256-256s-simple
    SPHINCS+-SHAKE256: SPHINCS+-SHAKE256-128f-robust, SPHINCS+-SHAKE256-128f-simple, SPHINCS+-SHAKE256-128s-robust, SPHINCS+-SHAKE256-128s-simple, SPHINCS+-SHAKE256-192f-robust, SPHINCS+-SHAKE256-192f-simple, SPHINCS+-SHAKE256-192s-robust, SPHINCS+-SHAKE256-192s-simple, SPHINCS+-SHAKE256-256f-robust, SPHINCS+-SHAKE256-256f-simple, SPHINCS+-SHAKE256-256s-robust, SPHINCS+-SHAKE256-256s-simple
```

## Method-Specific DID URL Parameters

DID Url parameters as described under paragraph 5.2.3 https://www.w3.org/TR/did-core/#method-specific-did-url-parameters in the W3C specification are implemented with preference to 
**DID method namespaces** over method-specific parameters within the **did:vsoc** namespace.
Unique Identifiers are created by implementing the Universally Unique Identifier (UUID) as defined by [RFC4122] https://tools.ietf.org/html/rfc4122.
in a 22 character alphanumeric format (short uuid).

The following is prefered:

*example*
```
did:vsoc:consensus:vote:Zy8MVKupFES9NpmZ9TiHcw
```

Over

*example*
```
did:vsoc:Zy8MVKupFES9NpmZ9TiHcw;consensus=vote
```

### Minimal

*example*
```
did:vsoc:s1Io8tx8TkmaepcaFgAmDA
```

### Consensus method namespaces

#### Blocking

For groups that require unanimity and use a core set of procedures to reach unified consnesus through a blocking procedure.

*example*
```
did:vsoc:consensus:block:At5KrBz6oU-Q7zQ6ffJ52Q
```

#### Vote

For groups that require majority voting principle and use a core set of voting procedures to reach that majority.

*example*
```
did:vsoc:consensus:vote:cWuKnlrY8UWHSVlWhoXFew
```

### Algorithmic method namespaces

For code generated for exascale computing (HPC) purposes the method namespace is as follows:

*example*
```
did:vsoc:gen:actor:y5CZFpo2d02O0utSn6Qhxw
```

Specifically these are virtual actors running on the Morstead implementation and are code generated and signed from DSL inputs.
The code also bears the mark refering its Did.

```CSHARP
/*
    /\     _____ _____ _____ _____ _____ _____ _____ ____  
  _(  )_  |     |     | __  |   __|_   _|   __|  _  |    \ 
 ( `==' ) | | | |  |  |    -|__   | | | |   __|     |  |  |
   '\/`   |_|_|_|_____|__|__|_____| |_| |_____|__|__|____/ 

          Generated Virtual Actor from rule DSL.
          Copyright© {DateTime.Now.Year} Virtual Society under MIT license
          Grain Generated at: {DateTime.UtcNow}
          did:vsoc:gen:actor:Zy8MVKupFES9NpmZ9TiHcw
*/
```

For more information (in dutch) about morstead please visit: https://github.com/sjefvanleeuwen/virtual-society-urukagina/blob/master/morstead/Readme.md

