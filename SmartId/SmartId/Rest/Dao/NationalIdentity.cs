namespace SmartId.Rest.Dao
{
    public class NationalIdentity
    {

        public string CountryCode { get; set; }
        public string NationalIdentityNumber { get; set; }

        public NationalIdentity()
        {
        }

        public NationalIdentity(string countryCode, string nationalIdentityNumber)
        {
            CountryCode = countryCode;
            NationalIdentityNumber = nationalIdentityNumber;
        }

        #region Override
        public override string ToString()
        {
            return "NationalIdentity{" +
       "countryCode='" + CountryCode + '\'' +
       ", nationalIdentityNumber='" + NationalIdentityNumber + '\'' +
       '}';
        }
        #endregion
    }
}
