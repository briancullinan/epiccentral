using System;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace EPICCentral.Providers
{
    /// <summary>
    /// Provides membership by calling the other listed membership providers.
    /// TODO: This may be unnecessary because MembershipProvider will find the first valid provider for the user.
    /// </summary>
    public class CombinedMembershipProvider : BaseMembershipProvider
    {
		public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
		{
			foreach (var provider in Membership.Providers.Cast<MembershipProvider>().Where(x => !(x is CombinedMembershipProvider)))
			{
				try
				{
					return provider.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
				}
				// ReSharper disable EmptyGeneralCatchClause
				catch
				// ReSharper restore EmptyGeneralCatchClause
				{
					// Go to next one ...
				}
			}

			status = MembershipCreateStatus.ProviderError;
			return null;
		}

        public override bool ValidateUser(string username, string password)
        {
			return Membership.Providers.Cast<MembershipProvider>().Where(x => !(x is CombinedMembershipProvider)).Any(provider => provider.ValidateUser(username, password));
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
			return Membership.Providers.Cast<MembershipProvider>().Where(x => !(x is CombinedMembershipProvider))
				.Select(provider => provider.GetUser(username, userIsOnline)).FirstOrDefault(result => result != null);
        }

		public override int MinRequiredPasswordLength
		{
			get
			{
				int? min = Membership.Providers.Cast<MembershipProvider>()
								.Where(x => !(x is CombinedMembershipProvider))
								.Select(provider =>
				                        {
				                            try
				                            {
				                                return (int?)provider.MinRequiredPasswordLength;
				                            }
				                            catch (Exception)
				                            {
				                                return null;
				                            }
				                        }).FirstOrDefault(result => result.HasValue);
				return min != null ? min.Value : 0;
			}
		}

		public override string PasswordStrengthRegularExpression
		{
			get
			{
				string expr = Membership.Providers.Cast<MembershipProvider>()
								.Where(x => !(x is CombinedMembershipProvider))
								.Select(provider => {
											try
											{
												return provider.PasswordStrengthRegularExpression;
											}
											catch (Exception)
											{
												return null;
											}
										}).FirstOrDefault(result => result != null);
				return expr;
			}
		}

        public override int GetNumberOfUsersOnline()
        {
            return Membership.Providers.Cast<MembershipProvider>().Where(x => x.Name == Membership.GetUser().ProviderName)
                .Sum(provider => provider.GetNumberOfUsersOnline());
        }
    }
}