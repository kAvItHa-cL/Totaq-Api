using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotaqWebAPI.DAL
{
    public class DocumentsDal
    {
        GTLOANEntities dbContext = new GTLOANEntities();
        
        public int UpdateAdharCard (AdharCardDocument AdharModel )
        {
            try
            {
                var documentexists = dbContext.AdharCardDocuments.Where(d => d.PhoneNumber == AdharModel.PhoneNumber).FirstOrDefault();
                if (documentexists == null)
                {
                    dbContext.AdharCardDocuments.Add(AdharModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                {
                    return 200;
                }
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Update AdharCard";
                int error = objError.InsertError(model);
                return 400;
            }

        }

        public int UpdatePANCard (PANCardDocument PANCardModel )
        {
            try
            {
                var documentexists = dbContext.PANCardDocuments.Where(d => d.PhoneNumber == PANCardModel.PhoneNumber).FirstOrDefault();
                if (documentexists == null)
                {
                    dbContext.PANCardDocuments.Add(PANCardModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                {
                    return 200;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Update PANCard";
                int error = objError.InsertError(model);
                return 400;
            }

        }
        public int UpdateBankStatement (BankstatementDocument BankStatementModel  )
        {
            try
            {
                var documentexists = dbContext.BankstatementDocuments.Where(d => d.PhoneNumber == BankStatementModel.PhoneNumber).FirstOrDefault();
                if (documentexists == null)
                {
                    dbContext.BankstatementDocuments.Add(BankStatementModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                {
                    return 200;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Update BankStatement";
                int error = objError.InsertError(model);
                return 400;
            }

        }
        public int UpdateSelfie(SelfieDocument SelfieModel )
        {
            try
            {
                var documentexists = dbContext.SelfieDocuments.Where(d => d.PhoneNumber == SelfieModel.PhoneNumber).FirstOrDefault();
                if (documentexists == null)
                {
                    dbContext.SelfieDocuments.Add(SelfieModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                {
                    return 200;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Update Selfie";
                int error = objError.InsertError(model);
                return 400;
            }

        }
        public int UpdateIDCard (IDCardDocument IDCardModel )
        {
            try
            {
                var documentexists = dbContext.IDCardDocuments.Where(d => d.PhoneNumber == IDCardModel.PhoneNumber).FirstOrDefault();
                if (documentexists == null)
                {
                    dbContext.IDCardDocuments.Add(IDCardModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                {
                    return 200;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Update IDCard";
                int error = objError.InsertError(model);
                return 400;
            }

        }

        public int UpdateSignature (SignatureDocument SignatureModel)
        {
            try
            {
                var documentexists = dbContext.SignatureDocuments.Where(d => d.PhoneNumber == SignatureModel.PhoneNumber).FirstOrDefault();
                if (documentexists == null)
                {
                    dbContext.SignatureDocuments.Add(SignatureModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                {
                    return 200;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Update Signature";
                int error = objError.InsertError(model);
                return 400;
            }

        }
        public int UpdatePaySlip (PaySlipDocument PayslipModel )
        {
            try
            {
                var documentexists = dbContext.PaySlipDocuments.Where(d => d.PhoneNumber == PayslipModel.PhoneNumber).FirstOrDefault();
                if (documentexists == null)
                {
                    dbContext.PaySlipDocuments.Add(PayslipModel);
                    dbContext.SaveChanges();
                    return 100;
                }
                else
                {
                    return 200;
                }
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Update PaySlip";
                int error = objError.InsertError(model);
                return 400;
            }

        }

        public AdharCardDocument FetchAdharCard(string PhoneNumber)
        {

            try
            {
                var Adharquery  = dbContext.AdharCardDocuments.Where(b => b.PhoneNumber == PhoneNumber).FirstOrDefault();
                return Adharquery;
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch AdharCard";
                int error = objError.InsertError(model);
                throw;
            }
        }

        public PANCardDocument FetchPANCard (string PhoneNumber)
        {

            try
            {
                var PANquery = dbContext.PANCardDocuments.Where(b => b.PhoneNumber == PhoneNumber).FirstOrDefault();
                return PANquery;
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch PANCard";
                int error = objError.InsertError(model);
                throw;
            }
        }

        public IDCardDocument FetchIDCard (string PhoneNumber)
        {

            try
            {
                var IDquery  = dbContext.IDCardDocuments.Where(b => b.PhoneNumber == PhoneNumber).FirstOrDefault();
                return IDquery;
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch IDCard";
                int error = objError.InsertError(model);
                throw;
            }
        }
        public PaySlipDocument FetchPaySlip (string PhoneNumber)
        {

            try
            {
                var query = dbContext.PaySlipDocuments.Where(b => b.PhoneNumber == PhoneNumber).FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch Payslip";
                int error = objError.InsertError(model);
                throw;
            }
        }
        public BankstatementDocument FetchBankStatement (string PhoneNumber)
        {

            try
            {
                var query = dbContext.BankstatementDocuments.Where(b => b.PhoneNumber == PhoneNumber).FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch BankStatement";
                int error = objError.InsertError(model);
                throw;
            }
        }
        public SelfieDocument FetchSelfie (string PhoneNumber)
        {

            try
            {
                var query = dbContext.SelfieDocuments.Where(b => b.PhoneNumber == PhoneNumber).FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {

                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch Selfie";
                int error = objError.InsertError(model);
                throw;
            }
        }
        public SignatureDocument FetchSignature (string PhoneNumber)
        {

            try
            {
                var query = dbContext.SignatureDocuments.Where(b => b.PhoneNumber == PhoneNumber).FirstOrDefault();
                return query;
            }
            catch (Exception ex)
            {
                ErrorLogDal objError = new ErrorLogDal();
                ErrorLog model = new ErrorLog();
                model.InnerException = ex.InnerException.InnerException.Message.ToString();
                model.Source = "Fetch Signature";
                int error = objError.InsertError(model);
                throw;
            }
        }
    }
}