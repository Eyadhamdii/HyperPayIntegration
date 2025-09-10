HyperPay API Documentation Notes:

Base URLs:
- Sandbox: https://sandbox.hyperpay.io
- Production: https://api.hyperpay.io

API Specification:
- Requests are authenticated using SHA256WithRSA.
- Both parameter names and URL are in lowercase.
- All date/time use GMT+8 (Beijing time).
- Pagination: `page` (current page number), `size` (records per page).
- All API use Unix timestamp (in second) for time/date related data.
- All amounts use string type to avoid loss of precision.
- All request body are using JSON format (Content-Type: application/json).
- Maximum range of records inquiry API must be less than 1 month.
- Internationalization: `en` (English), `zh-CN` (Chinese simplified). Set in request header.

Request Header Information:
- `timestamp`: long, true, Unix timestamp (in second)
- `nonce`: string, true, Random 10 characters string
- `api-key`: string, true, Merchant identification, provide by Hyperpay
- `signature`: string, true, Signature of request body + header request
- `version`: string, true, API version number, default 1.0
- `lang`: string, false, Language; Default English, this header need to be included into the signature.

API Respond Structure:
- `code`: string, Error code. 00000: Success, other than 00000: Unusual
- `msg`: string, Error message. Success respond would be “ok”
- `data`: object, Data

HTTP Response Codes:
- 200: OK
- 201: Created
- 401: Unauthorized
- 403: Forbidden
- 404: Not Found

Signature Generation Steps (SHA256WithRSA):
1. Pick and Sort:
   - Get all Request header information and request body.
   - Exclude `signature` field and fields with empty value.
   - Sort all fields by name of the parameter using ASCII code ordering (ascending).
2. Combine:
   - Using sorted parameter to form the new string using this formula `<parameter name>=<parameter value>`, and each parameter pair value are separated by `&` symbol.
   - Sign the combined string using SHA256WithRSA.
3. Invoke Signature function:
   - Use the SHA256WithRSA signature function with the private key to sign the combined string (RSA key length is 1024).
   - Encode the signature output into base64 format and append the value into `signature` field at request header.

